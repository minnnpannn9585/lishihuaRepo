using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightProp : MonoBehaviour
{
    Transform playerTrans;
    public float radius;
    public float speed;
    bool isgrip = false;
    bool isfly = false;

    void Start()
    {
        playerTrans = GameObject.Find("Player").transform;
    }

    private void OnMouseDown()
    {
        if(isgrip == false)
        {
            if (Vector3.Distance(transform.position, playerTrans.position) <= radius)
            {
                isfly = true;
                playerTrans.GetComponent<PlayerMovement>().isAttracted = true;
                Vector2 dir = transform.position - playerTrans.position;
                playerTrans.GetComponent<Rigidbody2D>().velocity = dir.normalized * speed;
                playerTrans.GetComponent<Rigidbody2D>().gravityScale = 0;
            }
        }
        else
        {
            isgrip = false;
            playerTrans.SetParent(null);
            playerTrans.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            playerTrans.GetComponent<Rigidbody2D>().gravityScale = 1;
            playerTrans.GetComponent<PlayerMovement>().isAttracted = false;
            playerTrans.rotation = Quaternion.identity;
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
     //   if (collision.gameObject.CompareTag("Player"))
     //   {
    //        playerTrans.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    //        playerTrans.SetParent(transform);
    //        isgrip = true;
    //    }
    //}

    private void Update()
    {
        if (isfly)
        {
            if(Vector3.Distance(transform.position, playerTrans.position) <= 1.5f)
            {
                isfly = false;
                playerTrans.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                playerTrans.SetParent(transform);
                isgrip = true;
            }
        }
    }
}
