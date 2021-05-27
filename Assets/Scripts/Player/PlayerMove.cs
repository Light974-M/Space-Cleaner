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
    private float dashCoolDown = 1.2f;
    public static bool isGodMod = false;
    private bool isDashing = false;
    private bool isRegainDash = false;
    private bool isLastChanceDashing = false;
    private bool lastChanceDashFirst = true;
    private int valueOfLastChanceDash = 0;
    private bool stabilizeDashing = false;

    private float dashSmooth = 2000;

    //initialisation des objets(vecteurs).
    private Vector3 memoVelocity;

    public DashBar dashBar;
    [Range(0,100)]
    private float dashBarValue;

    private float velocity;

    public AudioManager audioManager;

    //le start.
    private void Start()
    {
        Application.targetFrameRate = 60;
        player = gameObject;
        dashBarValue = 100;
    }

    //le update, principale boucle réappeller a chaques rafraichissements.
    private void Update()
    {
        dashBar.SetDash(dashBarValue);

        if (stabilizeDashing)
        {
            if(timer2 < 30)
            {
                rb.AddForce(-rb.velocity * 100);
                timer2++;
            }
            else
            {
                stabilizeDashing = false;
                timer2 = 0;
            }
        }

        if(!StatController.isGameOver && !LevelManager.isPause)
        {

            if (!isDashing && !tutoController.isSpeaking)
            {
                MoveAndStabilize();

                if(dashBarValue < 100)
                {
                    dashBarValue += 0.1f;
                }
                else
                {
                    isRegainDash = false;
                    dashBarValue = 100;
                }
            }

            if (!isGodMod && !StatController.lastChance && !tutoController.isSpeaking)
            {
                if(!isRegainDash)
                {
                    if (dashBarValue > 0)
                    {
                        if (Input.GetKey(KeyCode.LeftShift))
                        {
                            isDashing = true;
                            dashBarValue -= 0.5f;
                            Dash();
                            /*if (Input.GetKeyDown(KeyCode.LeftShift))
                            {
                                audioManager.PlayDashBegin();
                                StartCoroutine(audioManager.DashCoroutine());
                            }*/
                        }
                        else
                        {
                            isDashing = false;
                            dashSmooth = 2000;
                            timer = 0;
                        }
                    }
                    else
                    {
                        isDashing = false;
                        dashSmooth = 2000;
                        timer = 0;
                        isRegainDash = true;
                    }
                }
            }
            else
            {
                timer = 0;
                dashBarValue = 300;
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
        }

        velocity = Mathf.Sqrt((rb.velocity.x * rb.velocity.x) + (rb.velocity.y * rb.velocity.y) + (rb.velocity.z * rb.velocity.z));

        if(!isLastChanceDashing && !isGodMod)
        {
            if(camMain.fieldOfView < 140)
            {
                camMain.fieldOfView = 60 + velocity;
            }
            else
            {
                camMain.fieldOfView = 139;
            }
        }
    }

    //la fonction de déplacement et de stabilisation.
    private void MoveAndStabilize()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            if (rb.velocity.magnitude < 20)
            {
                rb.AddForce(transform.forward * 400);
            }

            if(dashBarValue == 0)
            {
                stabilizeDashing = true;
            } 

            //rb.AddForce(0, 0, 0);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            if (rb.velocity.magnitude < 20)
            {
                rb.AddForce(transform.right * -400);
            }

            if (dashBarValue == 0)
            {
                stabilizeDashing = true;
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (rb.velocity.magnitude < 20)
            {
                rb.AddForce(transform.right * 400);
            }

            if (dashBarValue == 0)
            {
                stabilizeDashing = true;
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (rb.velocity.magnitude < 20)
            {
                rb.AddForce(transform.forward * -400);
            }

            if (dashBarValue == 0)
            {
                stabilizeDashing = true;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                rb.AddForce(-rb.velocity * 130);
            }

            rb.AddForce(-rb.velocity * 25);
        }
    }

    //la fonction de dash.
    private void Dash()
    {
        if(timer < 60)
        {
            rb.AddForce(transform.forward * dashSmooth);
            dashSmooth -= 33;
            timer++;
        }
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
                StatController.LoseLife(-10);
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                StatController.LoseLife(10);
            }


        }
    }

    private void LastChanceDash(int valueOfLastChanceDash)
    {
        if (timer3 == 0)
        {
            memoVelocity = rb.velocity;
            rb.AddForce(transform.right * valueOfLastChanceDash);
        }
        if (timer3 >= 100 && timer < 110)
        {
            rb.AddForce(-rb.velocity * 800);
        }

        if (timer3 > 0 && timer3 < 50)
        {
            camMain.fieldOfView += 1f;
        }

        if (timer3 > 60 && timer3 < 110)
        {
            camMain.fieldOfView -= dashCoolDown;
            dashCoolDown = dashCoolDown / 1.027f;
        }
        if (timer3 == 110)
        {
            audioManager.PlayBulletTimeEnd();
            isLastChanceDashing = false;
            dashCoolDown = 1.2f;
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
        player.GetComponent<Rigidbody>().AddForce(-player.GetComponent<Rigidbody>().velocity * 8000);
        player.GetComponent<Rigidbody>().AddTorque(1000, 1000, 1000);
    }
}
