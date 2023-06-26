using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    public Slider slider;
    private string sliderKey = "SliderValue";

    private void Start()
    {
        if (PlayerPrefs.HasKey(sliderKey))
        {
            float savedValue = PlayerPrefs.GetFloat(sliderKey);
            slider.normalizedValue = savedValue;
        }

    }

    public void OnSliderValueChanged()
    {

        PlayerPrefs.SetFloat(sliderKey, slider.value);
        PlayerPrefs.Save();
    }

    
}