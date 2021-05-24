using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public AudioManager audioManager;
    public GameObject flash;
    public GameObject wastedGameOver;

    public PauseButtonController pauseController;
    public GameObject GameOverWindow;

    private int timer = 0;
    private int timer2 = 0;
    private float fixedDeltaTime = 0.02f;
    
    public static bool isPause = false;
	public int trashRemaining;
    public Text trashRemainingText;

    private bool isLastChancePassingToFalse = false;

    // Pour un pop plus aléatoire des déchets
    public List<Transform> garbageSpawns;
    public List<GameObject> garbages;

    void Start()
    {
        StatController.isGameOver = false;
        StatController.life = 100;
        
        trashRemaining = 8;
        SetTrashReminding();

        Time.timeScale = 1;
        Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;

        if (SceneManager.GetActiveScene().name == "tuto")
        {
            tutoController.isSpeaking = false;
            tutoController.speakingIndex = 0;
        }
        else
        {
            tutoController.isSpeaking = false;

            /*for (int i = 0; i < 5; i++)
            {
                GameObject newGarbage = Instantiate(garbages[UnityEngine.Random.Range(0, garbages.Count)], garbageSpawns[UnityEngine.Random.Range(0, garbageSpawns.Count)]);
                Debug.Log("1 déchet");
            }*/
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
                GameOverWindow.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
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
                pauseController.Pause();
            }
        }

        // Si on veut que des trucs soit pas compliés :
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
            isLastChancePassingToFalse = true;

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
            if(isLastChancePassingToFalse)
            {
                flash.SetActive(false);
                Time.timeScale = 1;
                Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
                timer = 0;

                isLastChancePassingToFalse = false;
            }
        }
    }
}

// Pour avoir des List de List (pour les routes)
[Serializable]
public class Routes
{
    public List<Transform> waypoints;
}