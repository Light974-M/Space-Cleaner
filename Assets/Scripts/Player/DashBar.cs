using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DashBar : MonoBehaviour
{
    public Slider slider;

    public void SetDash(float dashValue)
    {
        slider.value = dashValue;
    }
}