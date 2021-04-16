using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatController : MonoBehaviour
{
    [Range(0, 100)]
    public static int life = 100;

    public static bool lastChance = false;
    private int timer = 0;
    private float fixedDeltaTime;

    public GameObject flash;

    void Start()
    {
        this.fixedDeltaTime = Time.fixedDeltaTime;
    }

    void Update()
    {

        if(lastChance)
        {
            flash.SetActive(true);
            //flash.GetComponent<SpriteRenderer>().material.color = Color(1, 1, 1, 0);
            Time.timeScale = 0.3f;
            Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
            timer++;

            if (timer > 1000)
            {
                lastChance = false;
            }
        }
        else
        {
            flash.SetActive(false);
            Time.timeScale = 1;
            Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
            timer = 0;
        }
    }

    private Color Color(int v1, int v2, int v3, double v4)
    {
        throw new NotImplementedException();
    }

    private void OnCollisionEnter(Collision collision)
    {
        loseLife(8);
    }

    public static void loseLife(int lose)
    {
        life -= lose;
        life = Mathf.Clamp(life, 0, 100);
        Debug.Log(life);
        if (life <= 10)
        {
            lastChance = true;
        }
    }
}
