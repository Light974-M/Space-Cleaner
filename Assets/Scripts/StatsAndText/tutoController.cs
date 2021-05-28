using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class tutoController : MonoBehaviour
{
    private GameObject player;

    private GameObject bouttonPass;
    private GameObject fondTuto;

    private GameObject text1;
    private GameObject text2;
    private GameObject text3;
    private GameObject text4;
    private GameObject text5;
    private GameObject text6;
    private GameObject text7;
    private GameObject text8;
    private GameObject text9;
    private GameObject text10;
    private GameObject text11;
    private GameObject text12;
    private GameObject text13;
    private GameObject text14;
    private GameObject text15;
    private GameObject textLoop1;
    private GameObject textConstant1;
    private GameObject textConstant2;
    private GameObject textConstant3;
    private GameObject textConstant4;
    private GameObject textConstant5;

    public Button passButton;

    public static bool isSpeaking = false;
    public static int speakingIndex = 0;

    private float fixedDeltaTime = 0.02f;

    private bool isZ = false;
    private bool isS = false;
    private bool isQ = false;
    private bool isD = false;
    private bool isLeftCtrl = false;
    private bool isLooping = false;

    private int timer = 0;

    private int memoSpeakingIndex = 0;
    private int nonSpeakingPhaseSelector = 1000;

    public garbageController garbageController;

    void Start()
    {
        player = GameObject.Find("PivotCam");
        text1 = GameObject.Find("text1");
        text2 = GameObject.Find("text2");
        text3 = GameObject.Find("text3");
        text4 = GameObject.Find("text4");
        text5 = GameObject.Find("text5");
        text6 = GameObject.Find("text6");
        text7 = GameObject.Find("text7");
        text8 = GameObject.Find("text8");
        text9 = GameObject.Find("text9");
        text10 = GameObject.Find("text10");
        text11 = GameObject.Find("text11");
        text12 = GameObject.Find("text12");
        text13 = GameObject.Find("text13");
        text14 = GameObject.Find("text14");
        text15 = GameObject.Find("text15");
        textLoop1 = GameObject.Find("textLoop1");

        textConstant1 = GameObject.Find("textConstant1");
        textConstant2 = GameObject.Find("textConstant2");
        textConstant3 = GameObject.Find("textConstant3");
        textConstant4 = GameObject.Find("textConstant4");
        textConstant5 = GameObject.Find("textConstant5");

        fondTuto = GameObject.Find("TutoTextFond");
        bouttonPass = GameObject.Find("passText");

        passButton.onClick.AddListener(Pass);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;


        SwitchSpeaking();
    }

    void Update()
    {
        if(isSpeaking)
        {
            SetIndexSpeaking();
        }

        NonTextPhase(nonSpeakingPhaseSelector);

        if(PlayerMove.isGodMod)
        {
            if(Input.GetKeyDown(KeyCode.P))
            {
                speakingIndex = 13;
            }
        }

        if(isSpeaking)
        {
            if (Input.GetKeyDown(KeyCode.Space) | Input.GetKeyDown(KeyCode.Return))
            {
                Pass();
            }
        }
    }

    private void SwitchSpeaking()
    {
        isSpeaking = !isSpeaking;

        if (isSpeaking)
        {
            fondTuto.SetActive(true);
            bouttonPass.SetActive(true);
            Time.timeScale = 1f;
            Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;

        }
        else
        {
            text1.SetActive(false);
            text2.SetActive(false);
            text3.SetActive(false);
            text4.SetActive(false);
            text5.SetActive(false);
            text6.SetActive(false);
            text7.SetActive(false);
            text8.SetActive(false);
            text9.SetActive(false);
            text10.SetActive(false);
            text11.SetActive(false);
            text12.SetActive(false);
            text13.SetActive(false);
            text14.SetActive(false);
            text15.SetActive(false);
            textLoop1.SetActive(false);

            fondTuto.SetActive(false);
            bouttonPass.SetActive(false);
            Time.timeScale = 1f;
            Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    private void Pass()
    {
        if(speakingIndex == 1 || speakingIndex == 3 || speakingIndex == 5 || speakingIndex == 7 || speakingIndex == 10)
        {
            memoSpeakingIndex = speakingIndex;
            speakingIndex = 2000;
        }
        else
        {
            speakingIndex++;
        }
    }

    private void SetIndexSpeaking()
    {
        if (speakingIndex == 0)
        {
            text1.SetActive(true);
            text2.SetActive(false);
            text3.SetActive(false);
            text4.SetActive(false);
            text5.SetActive(false);
            text6.SetActive(false);
            text7.SetActive(false);
            text8.SetActive(false);
            text9.SetActive(false);
            text10.SetActive(false);
            text11.SetActive(false);
            text12.SetActive(false);
            text13.SetActive(false);
            text14.SetActive(false);
            text15.SetActive(false);
            textLoop1.SetActive(false);

            textConstant1.SetActive(false);
            textConstant2.SetActive(false);
            textConstant3.SetActive(false);
            textConstant4.SetActive(false);
            textConstant5.SetActive(false);
        }
        else if (speakingIndex == 1)
        {
            text1.SetActive(false);
            text2.SetActive(true);
            text3.SetActive(false);
            text4.SetActive(false);
            text5.SetActive(false);
            text6.SetActive(false);
            text7.SetActive(false);
            text8.SetActive(false);
            text9.SetActive(false);
            text10.SetActive(false);
            text11.SetActive(false);
            text12.SetActive(false);
            text13.SetActive(false);
            text14.SetActive(false);
            text15.SetActive(false);
            textLoop1.SetActive(false);

            textConstant1.SetActive(true);

            nonSpeakingPhaseSelector = 1000;
        }
        else if (speakingIndex == 2)
        {
            text1.SetActive(false);
            text2.SetActive(false);
            text3.SetActive(true);
            text4.SetActive(false);
            text5.SetActive(false);
            text6.SetActive(false);
            text7.SetActive(false);
            text8.SetActive(false);
            text9.SetActive(false);
            text10.SetActive(false);
            text11.SetActive(false);
            text12.SetActive(false);
            text13.SetActive(false);
            text14.SetActive(false);
            text15.SetActive(false);
            textLoop1.SetActive(false);

            textConstant1.SetActive(false);
        }
        else if (speakingIndex == 3)
        {
            text1.SetActive(false);
            text2.SetActive(false);
            text3.SetActive(false);
            text4.SetActive(true);
            text5.SetActive(false);
            text6.SetActive(false);
            text7.SetActive(false);
            text8.SetActive(false);
            text9.SetActive(false);
            text10.SetActive(false);
            text11.SetActive(false);
            text12.SetActive(false);
            text13.SetActive(false);
            text14.SetActive(false);
            text15.SetActive(false);
            textLoop1.SetActive(false);

            textConstant2.SetActive(true);
            textConstant1.SetActive(false);

            isZ = false;
            nonSpeakingPhaseSelector = 1001;
        }
        else if (speakingIndex == 4)
        {
            text1.SetActive(false);
            text2.SetActive(false);
            text3.SetActive(false);
            text4.SetActive(false);
            text5.SetActive(true);
            text6.SetActive(false);
            text7.SetActive(false);
            text8.SetActive(false);
            text9.SetActive(false);
            text10.SetActive(false);
            text11.SetActive(false);
            text12.SetActive(false);
            text13.SetActive(false);
            text14.SetActive(false);
            text15.SetActive(false);
            textLoop1.SetActive(false);

            textConstant2.SetActive(false);

        }
        else if (speakingIndex == 5)
        {
            text1.SetActive(false);
            text2.SetActive(false);
            text3.SetActive(false);
            text4.SetActive(false);
            text5.SetActive(false);
            text6.SetActive(true);
            text7.SetActive(false);
            text8.SetActive(false);
            text9.SetActive(false);
            text10.SetActive(false);
            text11.SetActive(false);
            text12.SetActive(false);
            text13.SetActive(false);
            text14.SetActive(false);
            text15.SetActive(false);
            textLoop1.SetActive(false);

            textConstant3.SetActive(true);

            isZ = false;
            isS = false;
            isQ = false;
            isD = false;
            isLeftCtrl = false;

            nonSpeakingPhaseSelector = 1002;
        }
        else if (speakingIndex == 6)
        {
            text1.SetActive(false);
            text2.SetActive(false);
            text3.SetActive(false);
            text4.SetActive(false);
            text5.SetActive(false);
            text6.SetActive(false);
            text7.SetActive(true);
            text8.SetActive(false);
            text9.SetActive(false);
            text10.SetActive(false);
            text11.SetActive(false);
            text12.SetActive(false);
            text13.SetActive(false);
            text14.SetActive(false);
            text15.SetActive(false);
            textLoop1.SetActive(false);

            textConstant3.SetActive(false);
        }
        else if (speakingIndex == 7)
        {
            text1.SetActive(false);
            text2.SetActive(false);
            text3.SetActive(false);
            text4.SetActive(false);
            text5.SetActive(false);
            text6.SetActive(false);
            text7.SetActive(false);
            text8.SetActive(true);
            text9.SetActive(false);
            text10.SetActive(false);
            text11.SetActive(false);
            text12.SetActive(false);
            text13.SetActive(false);
            text14.SetActive(false);
            text15.SetActive(false);
            textLoop1.SetActive(false);

            textConstant4.SetActive(true);

            isZ = false;
            nonSpeakingPhaseSelector = 1003;
        }
        else if (speakingIndex == 8)
        {
            text1.SetActive(false);
            text2.SetActive(false);
            text3.SetActive(false);
            text4.SetActive(false);
            text5.SetActive(false);
            text6.SetActive(false);
            text7.SetActive(false);
            text8.SetActive(false);
            text9.SetActive(true);
            text10.SetActive(false);
            text11.SetActive(false);
            text12.SetActive(false);
            text13.SetActive(false);
            text14.SetActive(false);
            text15.SetActive(false);
            textLoop1.SetActive(false);

            textConstant4.SetActive(false);

        }
        else if (speakingIndex == 9)
        {
            text1.SetActive(false);
            text2.SetActive(false);
            text3.SetActive(false);
            text4.SetActive(false);
            text5.SetActive(false);
            text6.SetActive(false);
            text7.SetActive(false);
            text8.SetActive(false);
            text9.SetActive(false);
            text10.SetActive(true);
            text11.SetActive(false);
            text12.SetActive(false);
            text13.SetActive(false);
            text14.SetActive(false);
            text15.SetActive(false);
            textLoop1.SetActive(false);
        }
        else if (speakingIndex == 10)
        {
            text1.SetActive(false);
            text2.SetActive(false);
            text3.SetActive(false);
            text4.SetActive(false);
            text5.SetActive(false);
            text6.SetActive(false);
            text7.SetActive(false);
            text8.SetActive(false);
            text9.SetActive(false);
            text10.SetActive(false);
            text11.SetActive(true);
            text12.SetActive(false);
            text13.SetActive(false);
            text14.SetActive(false);
            text15.SetActive(false);
            textLoop1.SetActive(false);

            textConstant5.SetActive(true);

            isZ = false;
            isQ = true;
            nonSpeakingPhaseSelector = 1004;
        }
        else if (speakingIndex == 11)
        {
            text1.SetActive(false);
            text2.SetActive(false);
            text3.SetActive(false);
            text4.SetActive(false);
            text5.SetActive(false);
            text6.SetActive(false);
            text7.SetActive(false);
            text8.SetActive(false);
            text9.SetActive(false);
            text10.SetActive(false);
            text11.SetActive(false);
            text12.SetActive(true);
            text13.SetActive(false);
            text14.SetActive(false);
            text15.SetActive(false);
            textLoop1.SetActive(false);

            textConstant5.SetActive(false);
        }
        else if (speakingIndex == 12)
        {
            text1.SetActive(false);
            text2.SetActive(false);
            text3.SetActive(false);
            text4.SetActive(false);
            text5.SetActive(false);
            text6.SetActive(false);
            text7.SetActive(false);
            text8.SetActive(false);
            text9.SetActive(false);
            text10.SetActive(false);
            text11.SetActive(false);
            text12.SetActive(false);
            text13.SetActive(true);
            text14.SetActive(false);
            text15.SetActive(false);
            textLoop1.SetActive(false);
        }
        else if (speakingIndex == 13)
        {
            text1.SetActive(false);
            text2.SetActive(false);
            text3.SetActive(false);
            text4.SetActive(false);
            text5.SetActive(false);
            text6.SetActive(false);
            text7.SetActive(false);
            text8.SetActive(false);
            text9.SetActive(false);
            text10.SetActive(false);
            text11.SetActive(false);
            text12.SetActive(false);
            text13.SetActive(false);
            text14.SetActive(true);
            text15.SetActive(false);
            textLoop1.SetActive(false);
        }
        else if (speakingIndex == 14)
        {
            text1.SetActive(false);
            text2.SetActive(false);
            text3.SetActive(false);
            text4.SetActive(false);
            text5.SetActive(false);
            text6.SetActive(false);
            text7.SetActive(false);
            text8.SetActive(false);
            text9.SetActive(false);
            text10.SetActive(false);
            text11.SetActive(false);
            text12.SetActive(false);
            text13.SetActive(false);
            text14.SetActive(false);
            text15.SetActive(true);
            textLoop1.SetActive(false);
        }
        else if (speakingIndex == 15)
        {
            SceneManager.LoadScene("menu");
        }
        else if (speakingIndex == 210)
        {
            text1.SetActive(false);
            text2.SetActive(false);
            text3.SetActive(false);
            text4.SetActive(false);
            text5.SetActive(false);
            text6.SetActive(false);
            text7.SetActive(false);
            text8.SetActive(false);
            text9.SetActive(false);
            text10.SetActive(false);
            text11.SetActive(false);
            textLoop1.SetActive(true);
        }
        else if(speakingIndex == 211)
        {
            speakingIndex = 10;
        }
    }

    private void NonTextPhase(int nonSpeakingPhaseSelector)
    {
        if (speakingIndex == 2000)
        {
            SwitchSpeaking();
            timer = 0;
            speakingIndex = nonSpeakingPhaseSelector;
        }
        if (speakingIndex == 2001)
        {
            SwitchSpeaking();
            if(isLooping)
            {
                speakingIndex = memoSpeakingIndex + 200;
            }
            else
            {
                speakingIndex = memoSpeakingIndex + 1;
            }
        }

        if (speakingIndex == 1000)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                isZ = true;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                isS = true;
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                isQ = true;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                isD = true;
            }

            if (isZ && isS && isD && isQ)
            {
                if (timer == 200)
                {
                    speakingIndex = 2001;
                    timer = 0;
                }
                timer++;
            }
        }
        
        if(speakingIndex == 1001)
        {
            if(Input.GetKeyDown(KeyCode.Z))
            {
                isZ = true;
            }
            if(Input.GetKeyDown(KeyCode.LeftControl))
            {
                isLeftCtrl = true;
            }

            if(isLeftCtrl && isZ)
            {
                if(timer == 200)
                {
                    speakingIndex = 2001;
                    timer = 0;
                }

                timer++;
            }
        }

        if (speakingIndex == 1002)
        {
            if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.D))
            {
                isZ = true;
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                timer++;
            }

            if (isZ)
            {
                if (timer == 100)
                {
                    speakingIndex = 2001;
                    timer = 0;
                }
            }
        }

        if (speakingIndex == 1003)
        {
            if (garbageController.isGrab)
            {
                isZ = true;
            }

            if (isZ)
            {
                if (timer == 300)
                {
                    speakingIndex = 2001;
                    timer = 0;
                }

                timer++;
            }
        }

        if (speakingIndex == 1004)
        {
            if(isQ)
            {
                StatController.LoseLife(StatController.life - 20);

                isQ = false;
            }

            if(Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.D))
            {
                isZ = true;
            }

            if (isZ)
            {
                if (timer > 500)
                {
                    speakingIndex = 2001;
                    timer = 0;
                    isLooping = false;
                }
            }
            else
            {
                if (timer > 500)
                {
                    speakingIndex = 2001;
                    StatController.LoseLife(80);

                    timer = 0;
                    isLooping = true;
                }
            }
            timer++;
        }
    }
}