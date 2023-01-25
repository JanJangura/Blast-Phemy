using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRangeCollision : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    public float Range;
    public float attackCoolDown;
    public GameObject enemy;

    private GameObject player;
    private bool detected = false;
    private float distance;
    private float timeSinceAttack = 6;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        timeSinceAttack += Time.deltaTime;

        if (detected == true)
        {
            Attack();
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            detected = true;
            enemy.GetComponent<EnemyIdle>().enabled = false;
        }
    }
    private void OnTriggerExit2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            detected = false;
            enemy.GetComponent<EnemyIdle>().enabled = true;
        }
    }

    private void Attack()
    {
        if (timeSinceAttack >= attackCoolDown && distance < Range)
        {
            timeSinceAttack = 0;
            Shoot();
        }
    }
    
    private void Shoot()
    {
        Instantiate(bullet, firePoint.position, Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
