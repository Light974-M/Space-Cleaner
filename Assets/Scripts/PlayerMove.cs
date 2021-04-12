using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody rb;

    public Transform garbage;

    private bool isHitted = false;

    private int timer = 0;
    private float rotateDown = 1;
    private float velocity;

    private float velocityX = 0;
    private float velocityY = 0;
    private float velocityZ = 0;


    private void Start()
    {
        
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.forward * 400);
            
        }
        else
        {
            rb.AddForce(-rb.velocity * 20);
        }


        if(isHitted)
        {
            if(timer < 400)
            {
                transform.Rotate(velocity / rotateDown, velocity / rotateDown, velocity / rotateDown);
                rotateDown = rotateDown * 1.01f;
                timer++;
            }
            else
            {
                isHitted = false;
            }
        }
        else
        {
            timer = 0;
            rotateDown = 1;
        }




        if (velocityX >= 0)
        {
            velocityX = rb.velocity.x;
        }
        else
        {
            velocityX = -rb.velocity.x;
        }

        if (velocityY >= 0)
        {
            velocityY = rb.velocity.y;
        }
        else
        {
            velocityY = -rb.velocity.y;
        }

        if (velocityZ >= 0)
        {
            velocityZ = rb.velocity.z;
        }
        else
        {
            velocityZ = -rb.velocity.z;
        }

        velocity = Mathf.Sqrt(velocityX * velocityX + velocityY * velocityY + velocityZ * velocityZ) / 15;

        if (velocity < 0.1f)
        {
            velocity = 0.1f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.layer != LayerMask.NameToLayer("Garbage"))
        {
            isHitted = true;
        }
    }
}
