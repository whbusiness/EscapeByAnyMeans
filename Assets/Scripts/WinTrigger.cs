using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class WinTrigger : MonoBehaviour
{
    private string Scene1, Scene2, CreditScene;
    private Scene currentScene;
    private TextMeshProUGUI Level1Text, Level2Text;
    // Start is called before the first frame update
    void Start()
    {
        Scene1 = "Level1";
        Scene2 = "Level2";
        CreditScene = "CreditScene";
        currentScene = SceneManager.GetActiveScene();
        if(currentScene.name == Scene1)
        {
            Level1Text = GameObject.Find("DisplayAmountOfDeathsNeeded").GetComponent<TextMeshProUGUI>();
            Level1Text.gameObject.SetActive(false);
        }
        else if(currentScene.name == Scene2)
        {
            Level2Text = GameObject.Find("DisplayAmountOfDeathsNeeded").GetComponent<TextMeshProUGUI>();
            Level2Text.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(currentScene.name == Scene1)
            {
                print("TOUCHED");
                if(Movement.EnemysKilled >= 5)
                {
                    SceneManager.LoadScene(Scene2);
                    PlayerPrefs.SetInt("LevelUnlocked", 2);
                }
                else
                {
                    StartCoroutine(nameof(DisplayTxt1), 3f);
                }
            }
            else if(currentScene.name == Scene2)
            {
                if (Movement.EnemysKilled >= 7)
                {//Load Credit Scene
                    SceneManager.LoadScene(nameof(CreditScene));
                    //PlayerPrefs.SetInt("LevelUnlocked", 3);
                }
                else
                {
                    StartCoroutine(nameof(DisplayTxt2), 3f);
                }
            }
        }
    }
    IEnumerator DisplayTxt1(float delay)
    {
        int AmountKilled = Movement.EnemysKilled;
        int MoreNeeded = 5 - AmountKilled;
        Level1Text.SetText("You need to kill " + MoreNeeded + " more to pass through");
        Level1Text.gameObject.SetActive(true);
        yield return new WaitForSeconds(delay);
        Level1Text.gameObject.SetActive(false);
    }
    IEnumerator DisplayTxt2(float delay)
    {
        int AmountKilled = Movement.EnemysKilled;
        int MoreNeeded = 7 - AmountKilled;
        Level2Text.SetText("You need to kill " + MoreNeeded + " more to pass through");
        Level2Text.gameObject.SetActive(true);
        yield return new WaitForSeconds(delay);
        Level2Text.gameObject.SetActive(false);
    }
}
