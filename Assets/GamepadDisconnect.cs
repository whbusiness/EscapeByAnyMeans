using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class GamepadDisconnect : MonoBehaviour
{
    private GameObject DisconnectedCanvas;
    private Scene currentScene;
    Movement instance;
    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene();
    }
    private void Start()
    {
        DisconnectedCanvas = GameObject.FindGameObjectWithTag("Disconnect");
        instance = GameObject.FindObjectOfType(typeof(Movement)) as Movement;
    }

    // Update is called once per frame
    void Update()
    {
        Gamepad g = Gamepad.current;
        if(g == null)
        {
            DisconnectedCanvas.SetActive(true);
            if (currentScene.name != "Main Menu" || currentScene.name != "CreditScene")
            {
                if (!instance.PauseMenuGO.activeInHierarchy && !instance.OptionsMenu.activeInHierarchy && !instance.RemapMenu.activeInHierarchy && !instance.ControlsMenu.activeInHierarchy && !LoseScreen.EndGameOverlay.activeInHierarchy)
                {
                    Movement.Pause = false;
                    instance.OnPause();
                }
            }
        }
        else
        {
            DisconnectedCanvas.SetActive(false);
        }
    }
}
