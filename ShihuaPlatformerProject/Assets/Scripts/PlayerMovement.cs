using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private Rigidbody2D rb;
    private float horizontalMove;
    private bool isGrounded;
    public LayerMask layer;

    public int jumpCount = 0;
    public GameObject jumpEffect;

    public bool isAttracted = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isAttracted) return;

        horizontalMove = Input.GetAxis("Horizontal");

        //if(Physics2D.Raycast(transform.position, Vector2.down, 0.2f, layer))
        //{
        //    isGrounded = true;
        //}
        //else
        //{
        //    isGrounded = false;
        //}

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpCount < 3)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0); // Reset vertical velocity
                rb.AddForce(Vector2.up * jumpForce);
                jumpCount += 1;
                Instantiate(jumpEffect, transform);
            }
        }
    }

    void FixedUpdate()
    {
        if (isAttracted) return;
        rb.velocity = new Vector2(horizontalMove * speed * Time.fixedDeltaTime, rb.velocity.y);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        jumpCount = 0; // Reset jump count when touching the ground
    //    }
    //}
}
