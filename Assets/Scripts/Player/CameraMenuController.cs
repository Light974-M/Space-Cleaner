using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMenuController : MonoBehaviour
{
    public GameObject Play;
    public GameObject Settings;
    public GameObject Quit;
    public GameObject QualitySettings;
    public GameObject SoundSettings;
    public GameObject GeneralSettings;
    public GameObject Return;
    public GameObject Yes;
    public GameObject No;
    public GameObject sure;

    void Start()
    {
        
    }

    void Update()
    {
        if(MenuButtonController.menuState == -1)
        {
            Play.SetActive(false);
            Settings.SetActive(false);
            Quit.SetActive(false);
            Yes.SetActive(true);
            No.SetActive(true);
            sure.SetActive(true);
        }

        if (MenuButtonController.menuState == 0)
        {
            QualitySettings.SetActive(false);
            SoundSettings.SetActive(false);
            GeneralSettings.SetActive(false);
            Return.SetActive(false);
            Yes.SetActive(false);
            No.SetActive(false);
            sure.SetActive(false);

            if (transform.position.x > 0)
            {
                transform.Translate(new Vector3(-103, 0, -62) * 1 * Time.deltaTime, Space.World);
            }
            else
            {
                transform.position = Vector3.zero;

                Play.SetActive(true);
                Settings.SetActive(true);
                Quit.SetActive(true);
            }
        }

        if(MenuButtonController.menuState == 1)
        {
            Play.SetActive(false);
            Settings.SetActive(false);
            Quit.SetActive(false);

            if (transform.position.x < 103)
            {
                transform.Translate(new Vector3(103, 0, 62) * 1 * Time.deltaTime, Space.World);
            }
            else
            {
                QualitySettings.SetActive(true);
                SoundSettings.SetActive(true);
                GeneralSettings.SetActive(true);
                Return.SetActive(true);

                transform.position = new Vector3(103, 0, 62);
            }
        }
    }
}
