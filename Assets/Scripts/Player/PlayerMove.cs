using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //initialisation des objets.
    public Rigidbody rb;
    public Transform garbage;
    public Camera camMain;
    public static GameObject player;

    //initialisation des variables numériques.
    private int timer = 0;
    private int timer2 = 0;
    private int timer3 = 0;
    private float rotateDown = 1;
    private float dashCoolDown = 1;
    public static bool isGodMod = false;
    private bool isDashing = false;
    private bool isLastChanceDashing = false;
    private bool lastChanceDashFirst = true;
    private int valueOfLastChanceDash = 0;

    //initialisation des objets(vecteurs).
    private Vector3 memoVelocity;

    //le start.
    private void Start()
    {
        Application.targetFrameRate = 60;
        player = gameObject;
    }

    //le update, principale boucle réappeller a chaques rafraichissements.
    private void Update()
    {
        if(!StatController.isGameOver && !LevelManager.isPause)
        {
            MoveAndStabilize();

            if (!isGodMod && !StatController.lastChance)
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

            if (StatController.lastChance)
            {
                if (Input.GetKeyDown(KeyCode.D) && lastChanceDashFirst)
                {
                    lastChanceDashFirst = false;
                    isLastChanceDashing = true;
                    valueOfLastChanceDash = 1000000;
                }

                if (Input.GetKeyDown(KeyCode.Q) && lastChanceDashFirst)
                {
                    lastChanceDashFirst = false;
                    isLastChanceDashing = true;
                    valueOfLastChanceDash = -1000000;
                }
            }
            else
            {
                isLastChanceDashing = false;
                lastChanceDashFirst = true;
            }

            if (isLastChanceDashing)
            {
                LastChanceDash(valueOfLastChanceDash);
            }
        }
        else
        {
            isDashing = false;
            camMain.fieldOfView = 60;
            camMain.GetComponent<Animator>().enabled = false;
        }
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
        if (StatController.lastChance)
        {
            isDashing = false;
            camMain.fieldOfView = 60;
            camMain.GetComponent<Animator>().enabled = false;
            rb.AddForce(-rb.velocity * 8000);
        }

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

    private void LastChanceDash(int valueOfLastChanceDash)
    {
        if (timer3 == 0)
        {
            camMain.GetComponent<Animator>().enabled = true;
            memoVelocity = rb.velocity;
            rb.AddForce(transform.right * valueOfLastChanceDash);
        }
        if (timer3 >= 200 && timer < 300)
        {
            rb.AddForce(-rb.velocity * 80);
        }
        if (timer3 > 1800)
        {
            isLastChanceDashing = false;
        }

        if (timer3 > 0 && timer3 < 50)
        {
            camMain.fieldOfView += 1f;
        }

        if (timer3 > 150 && timer3 < 300)
        {
            camMain.fieldOfView -= dashCoolDown;
            dashCoolDown = dashCoolDown / 1.02f;
        }
        if (timer3 == 300)
        {
            camMain.fieldOfView = 60;
            dashCoolDown = 1;
        }
        if (timer3 == 200)
        {
            camMain.GetComponent<Animator>().enabled = false;
        }
        
        timer3++;
    }

    public static void GameOverAutoRotate()
    {
        //player.transform.localEulerAngles += new Vector3(1, 1, 1);
    }

    public static void GameOverMoves()
    {
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        player.GetComponent<Rigidbody>().AddForce(-player.GetComponent<Rigidbody>().velocity * 40000);
        player.GetComponent<Rigidbody>().AddTorque(1000, 1000, 1000);
    }
}
