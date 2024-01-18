using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel, OptionsPanel, RemapPanel, ControlsPanel;
    public Button settingsBtn, remapBtn, aimRebind, returnBtn, controlsReturn, ControlsBtn;
    public Slider sensitivitySlider, volumeSlider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Sensitivity"))
        {
            sensitivitySlider.value = PlayerPrefs.GetInt("Sensitivity");
            Movement.rotSpeed = PlayerPrefs.GetInt("Sensitivity") * 10;
        }
        else
        {
            sensitivitySlider.value = sensitivitySlider.maxValue;
            Movement.rotSpeed = sensitivitySlider.maxValue * 10;
        }
    }

    public void OnResume()
    {
        PausePanel.SetActive(false);
        Movement.Pause = false;
    }
    public void OnOptions()
    {
        PausePanel.SetActive(false);
        OptionsPanel.SetActive(true);
        returnBtn.Select();
    }
    public void OnMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Movement.PlayerIsInvisible = false;
    }
    public void OnReturn()
    {
        OptionsPanel.SetActive(false);
        PausePanel.SetActive(true);
        settingsBtn.Select();
    }
    public void OnChangeSensitivity()
    {
        Movement.rotSpeed = sensitivitySlider.value*10;
        print(Movement.rotSpeed);
        PlayerPrefs.SetInt("Sensitivity", (int)sensitivitySlider.value);
        PlayerPrefs.Save();
    }

    public void OnReturnRemap()
    {
        RemapPanel.SetActive(false);
        OptionsPanel.SetActive(true);
        remapBtn.Select();
    }
    public void OnControls()
    {
        OptionsPanel.SetActive(false);
        ControlsPanel.SetActive(true);
        controlsReturn.Select();
    }
    public void OnReturnControls()
    {
        ControlsPanel.SetActive(false);
        OptionsPanel.SetActive(true);
        ControlsBtn.Select();
    }
    public void OnRemapKeys()
    {
        PausePanel.SetActive(false);
        OptionsPanel.SetActive(false);
        RemapPanel.SetActive(true);
        aimRebind.Select();
    }
}
