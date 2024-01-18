using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class OnLevelStart : MonoBehaviour
{
    private Scene currentScene;
    private TextMeshProUGUI LevelTxt;
    // Start is called before the first frame update
    void Start()
    {
        LevelTxt = GameObject.Find("LevelTxt").GetComponent<TextMeshProUGUI>();
        currentScene = SceneManager.GetActiveScene();
        if(currentScene.name == "Level1")
        {
            LevelTxt.SetText("Level1");
        }
        else if(currentScene.name == "Level2")
        {
            LevelTxt.SetText("Level2");
        }
        StartCoroutine(nameof(DisplayLevelName), 2f);
    }

    IEnumerator DisplayLevelName(float delay)
    {
        yield return new WaitForSeconds(delay);
        LevelTxt.enabled = false;
    }
}
