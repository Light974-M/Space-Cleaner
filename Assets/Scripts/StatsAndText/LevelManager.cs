﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject flash;
    public GameObject messageGameOver;
    public GameObject wastedGameOver;
    public GameObject buttonGameOver;
    public GameObject fondPause;
    public GameObject buttonResume;
    public GameObject buttonQuitToMenu;
    public GameObject buttonQuitToWindows;
    public GameObject buttonYes;
    public GameObject buttonNo;
    public GameObject textMenuQuit;
    public GameObject textWindowsQuit;

    private int timer = 0;
    private int timer2 = 0;
    private float fixedDeltaTime;
    
    public static bool isPause = false;
	public int trashRemaining;
    public Text trashRemainingText;

    void Start()
    {
        StatController.isGameOver = false;
        StatController.life = 100;
        Time.timeScale = 1;
        this.fixedDeltaTime = 0.02f;

        if (isPause)
        {
            SwitchPause();
        }
        
        trashRemaining = 5;
        SetTrashReminding();

        if (SceneManager.GetActiveScene().name == "tuto")
        {
            tutoController.isSpeaking = true;
            tutoController.speakingIndex = 0;
        }
        else
        {
            tutoController.isSpeaking = false;
        }
    }

    void Update()
    {
        wastedGameOver.transform.localScale = new Vector3(0.1646725f + (StatController.velocity / 300), 0.1086123f + (StatController.velocity / 300), 0.1086123f + (StatController.velocity / 300));

        if(!isPause)
        {
            lastChanceMethod();
        }

        if (StatController.isGameOver)
        {
            wastedGameOver.SetActive(true);
            PlayerMove.GameOverAutoRotate();

            if (timer2 == 0)
            {
                PlayerMove.GameOverMoves();
                wastedGameOver.GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, 0);

                StatController.alveol1.SetActive(true);
                StatController.alveol2.SetActive(true);
                StatController.alveol3.SetActive(true);
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
                messageGameOver.SetActive(true);
                buttonGameOver.SetActive(true);
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
            }

            if (timer2 == 20)
            {
                StatController.alveol3.SetActive(false);
            }
            if (timer2 == 23)
            {
                StatController.alveol2.SetActive(false);
            }
            if (timer2 == 26)
            {
                StatController.alveol1.SetActive(false);
            }

            timer2++;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!StatController.isGameOver)
            {
                SwitchPause();
            }
        }

        if(PauseButtonController.isResuming)
        {
            SwitchPause();
            PauseButtonController.isResuming = false;
        }

        if(isPause)
        {
            if (PauseButtonController.sureToQuitState == 0)
            {
                buttonResume.SetActive(true);
                buttonQuitToMenu.SetActive(true);
                buttonQuitToWindows.SetActive(true);
                buttonYes.SetActive(false);
                buttonNo.SetActive(false);
                textMenuQuit.SetActive(false);
                textWindowsQuit.SetActive(false);
            }
            else if (PauseButtonController.sureToQuitState == 1)
            {
                buttonResume.SetActive(false);
                buttonQuitToMenu.SetActive(false);
                buttonQuitToWindows.SetActive(false);
                buttonYes.SetActive(true);
                buttonNo.SetActive(true);
                textMenuQuit.SetActive(true);
            }
            else if (PauseButtonController.sureToQuitState == 2)
            {
                buttonResume.SetActive(false);
                buttonQuitToMenu.SetActive(false);
                buttonQuitToWindows.SetActive(false);
                buttonYes.SetActive(true);
                buttonNo.SetActive(true);
                textWindowsQuit.SetActive(true);
            }
        }

#if UNITY_EDITOR
        if(Input.GetKeyDown(KeyCode.A))
        {

        }
#endif
    }

    public void SetTrashReminding()
    {
        trashRemainingText.text = trashRemaining.ToString();
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
                Time.timeScale -= 0.015f;
                Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
                flash.GetComponent<SpriteRenderer>().material.color += new Color(0, 0, 0, 0.03f);
            }
            if (timer >= 450 && timer <= 500)
            {
                Time.timeScale += 0.015f;
                Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
                flash.GetComponent<SpriteRenderer>().material.color -= new Color(0, 0, 0, 0.03f);
            }

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

    public void SwitchPause()
    {
        if (isPause)
        {
            isPause = false;
            Time.timeScale = 1f;
            Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            fondPause.SetActive(false);
            buttonQuitToMenu.SetActive(false);
            buttonQuitToWindows.SetActive(false);
            buttonResume.SetActive(false);
            buttonYes.SetActive(false);
            buttonNo.SetActive(false);
            textMenuQuit.SetActive(false);
            textWindowsQuit.SetActive(false);
            PauseButtonController.sureToQuitState = 0;
        }
        else
        {
            isPause = true;
            Time.timeScale = 0f;
            Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            fondPause.SetActive(true);
            buttonQuitToMenu.SetActive(true);
            buttonQuitToWindows.SetActive(true);
            buttonResume.SetActive(true);
        }
    }
}

[Serializable]
public class Routes
{
    public List<Transform> waypoints;
}