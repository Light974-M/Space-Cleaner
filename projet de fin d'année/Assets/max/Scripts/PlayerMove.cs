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
    public float velocity;

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

        Debug.Log(velocity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.layer != LayerMask.NameToLayer("Garbage"))
        {
            isHitted = true;
            velocity = MathF.Sqrt(rb.velocity.x * rb.velocity.x + rb.velocity.y * rb.velocity.y + rb.velocity.z * rb.velocity.z);
        }
    }
}
