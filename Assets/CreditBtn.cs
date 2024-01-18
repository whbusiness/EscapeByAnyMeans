using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class CreditBtn : MonoBehaviour
{
    public TextMeshProUGUI killstxt, CapturedTxt, TimeTxt;
    private void Update()
    {
        killstxt.SetText("You Killed: " + Movement.TotalKillsDuringGameplay);
        CapturedTxt.SetText("You Were Captured " + LineofSight.AmountOfTimesCaptured + " Times");
        TimeTxt.SetText("You Spent " + (int)Movement.TimeInvisible + " Seconds Invisible");
    }
    public void OnMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
