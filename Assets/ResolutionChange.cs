using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResolutionChange : MonoBehaviour
{
    private TMP_Dropdown dropDown;
    // Start is called before the first frame update
    void Start()
    {

        dropDown = GetComponent<TMP_Dropdown>();
        if (PlayerPrefs.GetInt("Res") == 0 || !PlayerPrefs.HasKey("Res"))
        {
            dropDown.value = 0;
            Screen.SetResolution(1920, 1080, true, 60);
        }
        else if(PlayerPrefs.GetInt("Res") == 1)
        {
            dropDown.value = 1;
            Screen.SetResolution(1280, 720, true, 60);
        }
        else if(PlayerPrefs.GetInt("Res") == 2)
        {
            dropDown.value = 2;
            Screen.SetResolution(854, 480, true, 60);
        }
        dropDown.onValueChanged.AddListener(delegate
        {
            DropDownValueChanged(dropDown);
        });
    }

    void DropDownValueChanged(TMP_Dropdown valueChanged)
    {
        PlayerPrefs.SetInt("Res", valueChanged.value);
        if (valueChanged.value == 0)
        {
            dropDown.value = 0;
            Screen.SetResolution(1920, 1080, true, 60);
        }
        else if (valueChanged.value == 1)
        {
            dropDown.value = 1;
            Screen.SetResolution(1280, 720, true, 60);
        }
        else if (valueChanged.value == 2)
        {
            dropDown.value = 2;
            Screen.SetResolution(854, 480, true, 60);
        }
        print(PlayerPrefs.GetInt("Res"));
    }
}
