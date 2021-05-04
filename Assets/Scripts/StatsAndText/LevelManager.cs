using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject flash;
    public GameObject fondGameOver;
    public GameObject wastedGameOver;
    public GameObject buttonGameOver;

    private int timer = 0;
    private int timer2 = 0;
    private float fixedDeltaTime;

    void Start()
    {
        this.fixedDeltaTime = Time.fixedDeltaTime;
    }

    void Update()
    {
        lastChanceMethod();

        if (StatController.isGameOver)
        {
            wastedGameOver.SetActive(true);
            PlayerMove.GameOverAutoRotate();

            if (timer2 == 0)
            {
                PlayerMove.GameOverMoves();
                wastedGameOver.GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, 0);
            }

            if (timer2 <= 10)
            {
                wastedGameOver.GetComponent<SpriteRenderer>().material.color += new Color(0, 0, 0, 0.11f);
            }
            else if (timer2 <= 40)
            {
                wastedGameOver.GetComponent<SpriteRenderer>().material.color -= new Color(0, 0, 0, 0.01f);
            }

            if (timer2 == 150)
            {
                fondGameOver.SetActive(true);
                buttonGameOver.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }

            timer2++;
        }
    }

    private void lastChanceMethod()
    {
        if (StatController.lastChance)
        {
            flash.SetActive(true);
            if (timer == 0)
            {
                flash.GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, 0);
            }
            if (timer > 0 && timer < 50)
            {
                flash.GetComponent<SpriteRenderer>().material.color += new Color(0, 0, 0, 0.03f);
            }
            if (timer >= 450 && timer <= 500)
            {
                flash.GetComponent<SpriteRenderer>().material.color -= new Color(0, 0, 0, 0.03f);
            }
            Time.timeScale = 0.3f;
            Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
            timer++;

            if (timer > 500)
            {
                StatController.lastChance = false;
            }

            if (StatController.isGameOver)
            {
                StatController.lastChance = false;
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
}
