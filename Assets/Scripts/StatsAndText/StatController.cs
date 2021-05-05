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

    public Transform target;
    public Transform targetVelocity;

    public int timer = 0;


    private void Update()
    {
        if(stabilization)
        {
            if(timer > 150)
            {
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                stabilization = false;
                Debug.Log("here");
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
            loseLife(8);
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            GetComponent<Rigidbody>().AddForce(new Vector3(GetComponent<Rigidbody>().velocity.x * (1 / GetComponent<Rigidbody>().velocity.x), GetComponent<Rigidbody>().velocity.y * (1 / GetComponent<Rigidbody>().velocity.x), GetComponent<Rigidbody>().velocity.z * (1 / GetComponent<Rigidbody>().velocity.x)) * 50000);
            GetComponent<Rigidbody>().AddTorque(3000, 3000, 3000);
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
