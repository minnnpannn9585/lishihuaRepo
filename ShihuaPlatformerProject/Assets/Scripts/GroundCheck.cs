using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    //public bool isGrounded;
    PlayerMovement pm;

    private void Awake()
    {
        pm = transform.parent.GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            //isGrounded = true;
            pm.jumpCount = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            //isGrounded = false;
        }
    }
}
