using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMenuController : MonoBehaviour
{
    void Update()
    {
        if (MenuButtonController.menuState == 0)
        {
            if (transform.position.x > 0)
            {
                transform.Translate(new Vector3(-103, 0, -62) * Time.deltaTime, Space.World);
            }
            else
            {
                transform.position = Vector3.zero;
            }
        }

        if(MenuButtonController.menuState == 1)
        {

            if (transform.position.x < 103)
            {
                transform.Translate(new Vector3(103, 0, 62) * Time.deltaTime, Space.World);
            }
            else
            {
                transform.position = new Vector3(103, 0, 62);
            }
        }
    }

    public void Fonction1()
    {
        bool translateIsEnded = false;
        while(!translateIsEnded)
        {
            if (transform.position.x > 0)
            {
                transform.Translate(new Vector3(-103, 0, -62) * Time.deltaTime, Space.World);
                Debug.Log("Passage F1 :");
            }
            else
            {
                transform.position = Vector3.zero;
                translateIsEnded = true;
            }
        }
    }

    public void Fonction2()
    {
        bool translateIsEnded = false;
        while (!translateIsEnded)
        {
            if (transform.position.x < 103)
            {
                transform.Translate(new Vector3(103, 0, 62) * Time.deltaTime, Space.World);
                Debug.Log("Passage F2 :");
            }
            else
            {
                transform.position = new Vector3(103, 0, 62);
                translateIsEnded = true;
            }
        }
    }
}