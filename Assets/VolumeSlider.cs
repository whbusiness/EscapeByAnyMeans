using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] Slider vslider;
    
    void Start()
    {
        print(PlayerPrefs.GetFloat("Volume"));
        if (PlayerPrefs.HasKey("Volume"))
        {
            vslider.value = PlayerPrefs.GetFloat("Volume");
            AudioListener.volume = PlayerPrefs.GetFloat("Volume");
        }
        else
        {
            vslider.value = vslider.maxValue;
            AudioListener.volume = vslider.maxValue;
        }
    }

    public void OnChangeVolume()
    {
        AudioListener.volume = vslider.value;
        PlayerPrefs.SetFloat("Volume", vslider.value);
        PlayerPrefs.Save();
    }
}
