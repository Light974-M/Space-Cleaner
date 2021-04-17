using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //initialisation des objets.
    public Rigidbody rb;
    public Transform garbage;
    public Camera camMain;

    //initialisation des variables numériques.
    private int timer = 0;
    private int timer2 = 0;
    private float rotateDown = 1;
    private float dashCoolDown = 1;
    private bool isGodMod = false;
    private bool isDashing = false;

    //initialisation des objets(vecteurs).
    private Vector3 memoVelocity;

    //le start.
    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    //le update, principale boucle réappeller a chaques rafraichissements.
    private void Update()
    {

        MoveAndStabilize();

        if (!isGodMod)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                isDashing = true;
            }
        }

        if (isDashing)
        {
            Dash();
        }
        else
        {
            timer = 0;
        }

        GodMod();

        
    }

    //la fonction de déplacement et de stabilisation.
    private void MoveAndStabilize()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (rb.velocity.magnitude < 20)
            {
                rb.AddForce(transform.forward * 400);
            }
            else
            {
                rb.AddForce(-rb.velocity * 40);
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Mouse1))
            {
                rb.AddForce(-rb.velocity * 80);
            }
        }
    }

    //la fonction de dash.
    private void Dash()
    {
        if (timer == 0)
        {
            camMain.GetComponent<Animator>().enabled = true;
            memoVelocity = rb.velocity;
            rb.AddForce(transform.forward * 200000);
        }
        if (timer >= 200 && timer < 300)
        {
            rb.AddForce(-rb.velocity * 80);
        }
        if (timer > 1800)
        {
            isDashing = false;
        }

        if (timer > 0 && timer < 50)
        {
            camMain.fieldOfView += 1f;
        }

        if (timer > 150 && timer < 300)
        {
            camMain.fieldOfView -= dashCoolDown;
            dashCoolDown = dashCoolDown / 1.02f;
        }
        if (timer == 300)
        {
            camMain.fieldOfView = 60;
            dashCoolDown = 1;
        }
        if(timer == 200)
        {
            camMain.GetComponent<Animator>().enabled = false;
        }

        timer++;
    }

    //la fonction du GodMod.
    private void GodMod()
    {
        if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.RightAlt))
        {
            if (Input.GetKey(KeyCode.A) && Input.GetKeyDown(KeyCode.M))
            {
                if (isGodMod)
                {
                    isGodMod = false;
                }
                else
                {
                    isGodMod = true;
                }
            }
        }


        if (isGodMod)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                rb.AddForce(transform.forward * 10000);
            }
            else
            {
                rb.AddForce(-rb.velocity * 60);
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

            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                StatController.loseLife(-5);
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                StatController.loseLife(5);
            }


        }
    }

    private void lastChanceDash()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {

        }

        if (Input.GetKeyDown(KeyCode.Q))
        {

        }
    }
}
