using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    public float secCounter = 2;
    public float detectLength = 10;

    private GameObject player;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {      
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if(distance < detectLength)
        {
            timer += Time.deltaTime;

            if(timer > secCounter)
            {
                timer = 0;
                shoot();
            }
        }   
    }

    void shoot()
    {
        Instantiate(bullet, firePoint.position, Quaternion.identity);
    }
}
