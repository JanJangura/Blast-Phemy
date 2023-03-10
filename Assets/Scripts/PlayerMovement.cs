using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public Transform ceilingCheck;
    public Transform groundCheck;
    public LayerMask groundObjects;
    public float checkRadius;
    public Animator animator;
    public int maxHealth;
    public int currentHealth;
    public HealthBar healthBar;

    private Rigidbody2D rb;
    private bool facingRight = true;
    private float moveDirection;
    private bool isJumping = false;
    private bool isGrounded;


    // Awake is called after all objects initialized. Called in a random order.
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // Will look for a component on this GameObject (what the script is attached to) of type Rigidbody 2D/
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            // Get Player Inputs
            ProcessInputs();

            // Animate
            Animate();
        }
    }

    // Better for handling Physics
    private void FixedUpdate()
    {
        if (!PauseMenu.isPaused)
        {   
            // Check if we're grounded
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObjects);

            // Move
            Move();
            // Check if we're grounded
        }
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);

        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
        }
        isJumping = false;
    }
    private void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "Enemy Bullet")
        {
            TakeDamage(1);
        }
    }
    private void Animate()
    {
        if (moveDirection > 0 && !facingRight)
        {
            FlipCharacter();
        }
        else if (moveDirection < 0 && facingRight)
        {
            FlipCharacter();
        }
    }

    private void ProcessInputs()
    {
        moveDirection = Input.GetAxis("Horizontal"); // Scale of -1 > 1.

        // Sets off our walking animator
        animator.SetFloat("Speed", Mathf.Abs(moveDirection));

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }
    }

    private void FlipCharacter()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
