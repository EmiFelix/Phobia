using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Slider sliderVolume;
    public Slider sliderBrightness;
    public float sliderValue;
    public Image muteImage;
    public Image brightnessPanel;

    private void Start()
    {
        sliderVolume.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = sliderVolume.value;
        CheckIfSoundIsOff();

        sliderBrightness.value = PlayerPrefs.GetFloat("brightness", 0.5f);
        brightnessPanel.color = new Color(brightnessPanel.color.r, brightnessPanel.color.g, brightnessPanel.color.b, sliderBrightness.value);
    }

    public void ChangeVolumeSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("volumenAudio", sliderValue);
        AudioListener.volume = sliderVolume.value;
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

    public void ChangeBrightnessSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("brightness", sliderValue);
        brightnessPanel.color = new Color(brightnessPanel.color.r, brightnessPanel.color.g, brightnessPanel.color.b, sliderBrightness.value);
    }
}
