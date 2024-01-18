using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject Startmenu;
    public GameObject LevelMenu;
    public GameObject OptionMenu;
    public string Level1, Level2;
    public Button button, button2, startButton;

    public void OnStart()
    {
        Startmenu.SetActive(false);
        LevelMenu.SetActive(true);
        button2.Select();
    }
    public void OnOptions()
    {
        Startmenu.SetActive(false);
        OptionMenu.SetActive(true);
        button.Select();
    }
    public void OnQuit()
    {
        Application.Quit();
    }
    public void OnReturn()
    {
        OptionMenu.SetActive(false);
        LevelMenu.SetActive(false);
        Startmenu.SetActive(true);
        startButton.Select();
    }
    public void OnLevel1()
    {
        SceneManager.LoadScene(nameof(Level1));
        LineofSight.Lost = false;
        Movement.Pause = false;
        //LoseScreen.EndGameOverlay.SetActive(false);
        Movement.PlayerIsInvisible = false;
    }
    public void OnLevel2()
    {
        SceneManager.LoadScene(nameof(Level2));
        LineofSight.Lost = false;
        //LoseScreen.EndGameOverlay.SetActive(false);
        Movement.Pause = false;
        Movement.PlayerIsInvisible = false;
    }
}
