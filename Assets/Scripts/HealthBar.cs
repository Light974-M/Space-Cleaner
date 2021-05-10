using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        StartCoroutine(CoroutineStopHealthBar(health));
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
                Debug.Log("ok");
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
}