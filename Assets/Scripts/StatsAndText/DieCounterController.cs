using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DieCounterController : MonoBehaviour
{
    public static string matriculation = "model \nSC-35A756-";

    public static int matriculationNumber = 0000;

    public static bool isDied = false;



    void Start()
    {
        if(isDied)
        {
            
            PlayerPrefs.SetInt("load", 0);

            isDied = false;
        }

        if (PlayerPrefs.GetInt("load") == 1)
        {
            DieCounterController.matriculationNumber = PlayerPrefs.GetInt("dieCounter");
        }

        if (matriculationNumber < 10)
        {
            matriculation = "model \nSC-35A756-000";
            GetComponent<TextMeshProUGUI>().SetText(matriculation + matriculationNumber.ToString());
        }
        else if (matriculationNumber < 100)
        {
            matriculation = "model \nSC-35A756-00";
            GetComponent<TextMeshProUGUI>().SetText(matriculation + matriculationNumber.ToString());
        }
        else if (matriculationNumber < 1000)
        {
            matriculation = "model \nSC-35A756-0";
            GetComponent<TextMeshProUGUI>().SetText(matriculation + matriculationNumber.ToString());
        }
        else
        {
            matriculation = "model \nSC-35A756-";
            GetComponent<TextMeshProUGUI>().SetText(matriculation + matriculationNumber.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(StatController.isGameOver)
        {
            isDied = true;
        }
    }
}
