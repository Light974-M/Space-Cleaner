using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class StatController : MonoBehaviour
{
    [Range(0, 100)]
    public static int life;

    public static bool lastChance = false;
    public static bool lastChanceInit = false;
    public static bool isGameOver = false;
    public static bool stabilization = false;

    public static GameObject alveol1;
    public static GameObject alveol2;
    public static GameObject alveol3;

    private float x = 0;
    private float y = 0;

    public GameObject indicator;
    public GameObject car;

    public Transform target;
    public Transform targetVelocity;

    public int timer = 0;

    public HealthBar healthBar;

    public static float velocity;

    public AnimController animController;

    public AudioManager audioManager;

    private void Start()
    {
        alveol1 = GameObject.Find("AlveolModifier1");
        alveol2 = GameObject.Find("AlveolModifier2");
        alveol3 = GameObject.Find("AlveolModifier3");


        life = 100;   
    }

    private void Update()
    {
        velocity = Mathf.Sqrt((GetComponent<Rigidbody>().velocity.x* GetComponent<Rigidbody>().velocity.x) + (GetComponent<Rigidbody>().velocity.y * GetComponent<Rigidbody>().velocity.y) + (GetComponent<Rigidbody>().velocity.z * GetComponent<Rigidbody>().velocity.z));

        indicator.transform.LookAt(car.transform);
        indicator.transform.eulerAngles = new Vector3(indicator.transform.eulerAngles.x, indicator.transform.eulerAngles.y, transform.eulerAngles.z);
        if(indicator.transform.localEulerAngles.y > 45 && indicator.transform.localEulerAngles.y <= 170)
        {
            y = 45;
            indicator.transform.localEulerAngles = new Vector3(indicator.transform.localEulerAngles.x, y, indicator.transform.localEulerAngles.z);
        }
        if(indicator.transform.localEulerAngles.y < 315 && indicator.transform.localEulerAngles.y > 170)
        {
            y = 315;
            indicator.transform.localEulerAngles = new Vector3(indicator.transform.localEulerAngles.x, y, indicator.transform.localEulerAngles.z);
        }

        if(indicator.transform.localEulerAngles.x > 20 && indicator.transform.localEulerAngles.x <= 180)
        {
            x = 20;

            if (indicator.transform.localEulerAngles.y <= 45 && indicator.transform.localEulerAngles.y >= 0)
            {
                x -= (indicator.transform.localEulerAngles.y / 5) - 9;
            }
            if (indicator.transform.localEulerAngles.y >= 315 && indicator.transform.localEulerAngles.y <= 360)
            {
                x += ((indicator.transform.localEulerAngles.y - 315) / 5);
            }

            indicator.transform.localEulerAngles = new Vector3(x, indicator.transform.localEulerAngles.y, indicator.transform.localEulerAngles.z);
        }
        if (indicator.transform.localEulerAngles.x < 340 && indicator.transform.localEulerAngles.x > 180)
        {
            x = 340;

            if (indicator.transform.localEulerAngles.y <= 45 && indicator.transform.localEulerAngles.y >= 0)
            {
                x += (indicator.transform.localEulerAngles.y / 5) - 9;
            }
            if (indicator.transform.localEulerAngles.y >= 315 && indicator.transform.localEulerAngles.y <= 360)
            {
                x -= ((indicator.transform.localEulerAngles.y - 315) / 5);
            }

            indicator.transform.localEulerAngles = new Vector3(x, indicator.transform.localEulerAngles.y, indicator.transform.localEulerAngles.z);
        }

        if (stabilization)
        {

            if (timer > 150)
            {
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                stabilization = false;
            }
            GetComponent<Rigidbody>().AddForce(-GetComponent<Rigidbody>().velocity * 50);
            GetComponent<Rigidbody>().AddTorque(-GetComponent<Rigidbody>().angularVelocity * 50);

            if(timer == 0)
            {
                alveol1.SetActive(true);
                alveol2.SetActive(true);
                alveol3.SetActive(true);
            }
            if(timer == 20)
            {
                alveol3.SetActive(false);
            }
            if (timer == 23)
            {
                alveol2.SetActive(false);
            }
            if (timer == 26)
            {
                alveol1.SetActive(false);
            }

            timer++;
        }
        else
        {
            timer = 0;

            alveol1.SetActive(false);
            alveol2.SetActive(false);
            alveol3.SetActive(false);
        }
    }

    private Color Color(int v1, int v2, int v3, double v4)
    {
        throw new NotImplementedException();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("SpaceShip"))
        {
            audioManager.PlayImpact();
            LoseLife(20);
            healthBar.SetHealth(life);
            if (life > 0)
            {
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                GetComponent<Rigidbody>().AddForce(-GetComponent<Rigidbody>().velocity * (200000 / velocity));
                GetComponent<Rigidbody>().AddTorque(Random.Range(-80000,80000), Random.Range(-80000, 80000), Random.Range(-80000, 80000));
                stabilization = true;
                // Animation du coup
                animController.Damage();
            }
        }
    }

    public static void LoseLife(int lose)
    {
        if(life > 20)
        {
            lastChanceInit = true;
        }
        life -= lose;
        life = Mathf.Clamp(life, 0, 100);
        Debug.Log(life);
        if (life <= 20 && lastChanceInit)
        {
            lastChance = true;
        }
        if(life <= 0)
        {
            if(SceneManager.GetActiveScene().name == "tuto")
            {
                LoseLife(-100);
            }
            else
            {
                isGameOver = true;
            }
        }

        lastChanceInit = false;
    }
}
