using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelGetter : MonoBehaviour
{
    public List<Button> LevelBtns;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] levelBtn = GameObject.FindGameObjectsWithTag("LevelBtns");
        // Iterate through the array of 'btn' and add them to the 'buttons' list
        foreach(GameObject buttons in levelBtn)
        {
            LevelBtns.Add(buttons.GetComponent<Button>());
        }
        int getLevelUnlocked = PlayerPrefs.GetInt("LevelUnlocked");
        print("Level Unlocked = " + getLevelUnlocked);
        for (int i = 0; i < LevelBtns.Count; i++)
        {
            if (i >= getLevelUnlocked)
            {
                print(i + " ");
                LevelBtns[i].interactable = false;
            }
        }
    }
}
