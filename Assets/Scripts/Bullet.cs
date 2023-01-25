using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;

    // Right when the bullet spawns we want it to fly forward in the direction is spawnned in.
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)       // Whenever a gameobject enters a zone. We want to add Collider2D, this will store information of what we hit. 
    {
        if (hitInfo.tag == "Enemy" || hitInfo.tag == "Player" || hitInfo.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }
}
