using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class EndGameButtons : MonoBehaviour
{
   // private Button restartBtn;
    private Scene scene;
    private void Start()
    {
        scene = SceneManager.GetActiveScene();
        //restartBtn = GameObject.Find("Restart Level btn").GetComponent<Button>();
        //restartBtn.Select();
    }
    public void OnMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        LineofSight.Lost = false;
    }
    public void OnRestart()
    {
        print("Restart Clicked");
        if (scene.name == "Level1")
        {
            SceneManager.LoadScene("Level1");
        }
        else if(scene.name == "Level2")
        {
            SceneManager.LoadScene("Level2");
        }
        LineofSight.Lost = false;
        Movement.PlayerIsInvisible = false;
        LoseScreen.EndGameOverlay.SetActive(false);
    }
}
