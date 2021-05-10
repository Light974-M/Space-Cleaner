using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatController : MonoBehaviour
{
    [Range(0, 100)]
    public static int life;

    public static bool lastChance = false;
    public static bool lastChanceInit = false;
    public static bool isGameOver = false;
    public static bool stabilization = false;
    
    public Transform target;
    public Transform targetVelocity;

    public int timer = 0;

    public HealthBar healthBar;

    private float velocity;

    private void Start()
    {
        life = 100;   
    }

    private void Update()
    {
        velocity = Mathf.Sqrt((GetComponent<Rigidbody>().velocity.x* GetComponent<Rigidbody>().velocity.x) + (GetComponent<Rigidbody>().velocity.y * GetComponent<Rigidbody>().velocity.y) + (GetComponent<Rigidbody>().velocity.z * GetComponent<Rigidbody>().velocity.z));

        if(stabilization)
        {
            if(timer > 150)
            {
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                stabilization = false;
            }
            GetComponent<Rigidbody>().AddForce(-GetComponent<Rigidbody>().velocity * 50);
            GetComponent<Rigidbody>().AddTorque(-GetComponent<Rigidbody>().angularVelocity * 50);
            timer++;
        }
        else
        {
            timer = 0;
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
            LoseLife(20);
            healthBar.SetHealth(life);
            if(life > 0)
            {
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                GetComponent<Rigidbody>().AddForce(-GetComponent<Rigidbody>().velocity * (200000 / velocity));
                GetComponent<Rigidbody>().AddTorque(12000, 12000, 12000);
                stabilization = true;
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
            isGameOver = true;
        }

        lastChanceInit = false;
    }
}
