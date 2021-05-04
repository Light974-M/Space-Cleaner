using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverButtonController : MonoBehaviour
{
    public Button retry;
    public Button quit;

    void Start()
    {
        retry.onClick.AddListener(Retry);
        quit.onClick.AddListener(Quit);
    }

    void Update()
    {
        
    }

    void Retry()
    {
        StatController.life = 100;
        StatController.isGameOver = false;
        StatController.lastChance = false;
        StatController.lastChanceInit = false;
        SceneManager.LoadScene("max");
    }

    void Quit()
    {
        SceneManager.LoadScene("menu");
    }
}
