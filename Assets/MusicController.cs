using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MusicController : MonoBehaviour
{
    private AudioSource audioSource;
    private Scene currentScene;
    // Start is called before the first frame update
    private void Awake()
    {
        PlayerPrefs.SetInt("TotalKills", 0);
        PlayerPrefs.SetFloat("TimeInvisible", 0);
        PlayerPrefs.SetInt("AmountOfTimesCaptured", 0);
        if (!PlayerPrefs.HasKey("LevelUnlocked"))
        {
            PlayerPrefs.SetInt("LevelUnlocked", 1);
        }
        else
        {
            PlayerPrefs.GetInt("LevelUnlocked");
        }
        Cursor.visible = false;
        GameObject[] MusicItems = GameObject.FindGameObjectsWithTag("MusicController");
        if(MusicItems.Length > 1)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        currentScene = SceneManager.GetActiveScene();
        if (currentScene.name != "Main Menu" && currentScene.name != "CreditScene")
        {
            if (!Movement.Pause)
            {
                //print("Paused");
                audioSource.Pause();
            }
            else
            {
                audioSource.UnPause();
            }
            if (LoseScreen.EndGameOverlay.activeInHierarchy)
            {
                audioSource.UnPause();
            }
        }
        else
        {
            audioSource.UnPause();
        }
    }
}
