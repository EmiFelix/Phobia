using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image muteImage;

    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = slider.value;
        CheckIfSoundIsOff();
    }

    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("volumenAudio", sliderValue);
        AudioListener.volume = slider.value;
        CheckIfSoundIsOff();
    }

    public void CheckIfSoundIsOff()
    {
        if(sliderValue == 0)
        {
            muteImage.enabled = true;
        }
        else
        {
            muteImage.enabled = false;
        }
    }
}
