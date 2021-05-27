using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    public GameObject image4;

    private void Start()
    {
        image1.SetActive(false);
        image2.SetActive(false);
        image3.SetActive(false);
        image4.SetActive(false);
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        StartCoroutine(CoroutineStopHealthBar(health));
        if(health <= 60)
        {
            image1.SetActive(true);
            if(health <= 40)
            {
                image2.SetActive(true);
                if (health <= 20)
                {
                    image3.SetActive(true);
                    if(health <= 10)
                    {
                        image4.SetActive(true);
                    }
                }
            }
        }
    }

    IEnumerator CoroutineStopHealthBar(int health)
    {
        bool barIsOkay = false;
        while (!barIsOkay)
        {
            if (slider.value < health)
            {
                slider.value += 0.5f;
                Debug.Log("+1");
            }
            else if (slider.value > health)
            {
                slider.value -= 0.5f;
                Debug.Log("-1");
            }
            else if (slider.value == health)
            {
                barIsOkay = true;
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
}