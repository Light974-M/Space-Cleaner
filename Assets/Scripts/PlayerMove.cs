using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody rb;

    public Transform garbage;

    public Camera camMain;

    private int timer = 0;
    private float rotateDown = 1;

    private bool isGodMod = false;

    private bool isDashing = false;

    private Vector3 memoVelocity;

    private float dashCoolDown = 1;


    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if(rb.velocity.magnitude < 20)
            {
                rb.AddForce(transform.forward * 200);
            }
            else
            {
                rb.AddForce(-rb.velocity * 20);
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                rb.AddForce(-rb.velocity * 20);
            }
        }

        if (!isGodMod)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                isDashing = true;
            }
        }

        if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.RightAlt))
        {
            if(Input.GetKey(KeyCode.A) && Input.GetKeyDown(KeyCode.M))
            {
                if(isGodMod)
                {
                    isGodMod = false;
                }
                else
                {
                    isGodMod = true;
                }
            }
        }


        if(isGodMod)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                rb.AddForce(transform.forward * 100000);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                rb.constraints = RigidbodyConstraints.FreezePosition;
            }
            else
            {
                rb.constraints = RigidbodyConstraints.None;
                rb.constraints = RigidbodyConstraints.FreezeRotation;
            }
        }

        if(isDashing)
        {
            if(timer == 0)
            {
                camMain.GetComponent<Animator>().enabled = true;
                memoVelocity = rb.velocity;
                rb.AddForce(transform.forward * 100000);
            }
            if(timer == 200)
            {
                rb.velocity = memoVelocity;
            }
            if(timer > 1800)
            {
                isDashing = false;
            }

            if(timer > 0 && timer < 50)
            {
                camMain.fieldOfView += 1f;
            }

            if (timer > 150 && timer < 300)
            {
                camMain.fieldOfView -= dashCoolDown;
                dashCoolDown = dashCoolDown / 1.02f;
            }
            if(timer == 300)
            {
                camMain.GetComponent<Animator>().enabled = false;
                camMain.fieldOfView = 60;
                dashCoolDown = 1;
            }

            timer++;
        }
        else
        {
            timer = 0;
        }
    }
}
