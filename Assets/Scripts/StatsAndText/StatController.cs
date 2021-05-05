using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatController : MonoBehaviour
{
    [Range(0, 100)]
    public static int life = 100;

    public static bool lastChance = false;
    public static bool lastChanceInit = false;
    public static bool isGameOver = false;
    public static bool stabilization = false;


    private void Update()
    {
        if(stabilization)
        {
            GetComponent<Rigidbody>().AddForce(-GetComponent<Rigidbody>().velocity * 40);
            GetComponent<Rigidbody>().AddTorque(-10, -10, -10);
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
            loseLife(8);
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            GetComponent<Rigidbody>().AddForce(-GetComponent<Rigidbody>().velocity * 10000);
            GetComponent<Rigidbody>().AddTorque(1000, 1000, 1000);
            stabilization = true;
        }
    }

    public static void loseLife(int lose)
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
