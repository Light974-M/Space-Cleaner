using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class tutoController : MonoBehaviour
{
    private GameObject player;

    private GameObject text1;

    public Button passButton;

    public static bool isSpeaking = false;
    public static int speakingIndex = 0;

    private float fixedDeltaTime;

    void Start()
    {
        player = GameObject.Find("PivotCam");
        text1 = GameObject.Find("text1");

        passButton.onClick.AddListener(Pass);
    }

    void Update()
    {
        if (isSpeaking)
        {
            Time.timeScale = 0f;
            Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1f;
            Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    private void SwitchSpeaking()
    {
        isSpeaking = !isSpeaking;
    }

    private void Pass()
    {

    }
}
