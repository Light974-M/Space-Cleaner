using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour
{
    public string nameOfMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) | Input.GetKeyDown(KeyCode.Space))
        {
            GoMainMenu();
        }
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene(nameOfMenu);
    }
}