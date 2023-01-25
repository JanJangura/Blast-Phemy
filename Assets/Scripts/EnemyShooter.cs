using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    public float attackCoolDown;

    private GameObject player;
    private float timer;
    private float timeSinceAttack = 6;
    private bool detected;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        detected = true;
    }

    // Update is called once per frame
    void Update()
    {      
        float distance = Vector2.Distance(transform.position, player.transform.position);
        timeSinceAttack += Time.deltaTime;

        if (detected == true)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (timeSinceAttack >= attackCoolDown)
        {
            timeSinceAttack = 0;
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(bullet, firePoint.position, Quaternion.identity);
    }
}
