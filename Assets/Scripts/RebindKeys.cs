using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
public class RebindKeys : MonoBehaviour
{
    [SerializeField] InputActionReference RebindInvisibility, RebindAim, RebindSmoke;
    [SerializeField] GameObject RebindInvisibilityText, WaitingAimText, RebindSmokeText, WaitingInvisibilityText, RebindAimText, WaitingSmokeText;
    public InputActionRebindingExtensions.RebindingOperation rebindOp;
    [SerializeField] Button InvisibilityButton, AimButton, SmokeButton;

    public void RebindingInvisibility()
    {
        EventSystem.current.SetSelectedGameObject(null);
        RebindInvisibility.action.Disable();
        RebindInvisibilityText.SetActive(false);
        WaitingInvisibilityText.SetActive(true);
        rebindOp = RebindInvisibility.action.PerformInteractiveRebinding()
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation => CompleteRebindInvisibility())
            .Start();
        /*operation => CompleteRebindForRocket();
        {
            RebindMovementText.SetActive(true);
            rebindOp.Dispose();
            RebindRocket.action.Enable();
        }
        )
        .Start();   */
    }
    public void RebindingAim()
    {
        EventSystem.current.SetSelectedGameObject(null);
        RebindAim.action.Disable();
        RebindAimText.SetActive(false);
        WaitingAimText.SetActive(true);
        rebindOp = RebindAim.action.PerformInteractiveRebinding()
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation => CompleteRebindAim())
            .Start();
    }
    public void RebindingSmoke()
    {
        EventSystem.current.SetSelectedGameObject(null);
        RebindSmoke.action.Disable();
        RebindSmokeText.SetActive(false);
        WaitingSmokeText.SetActive(true);
        rebindOp = RebindSmoke.action.PerformInteractiveRebinding()
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation => CompleteRebindSmoke())
            .Start();
    }
    private void CompleteRebindAim()
    {
        WaitingAimText.SetActive(false);
        RebindAimText.SetActive(true);
        rebindOp.Dispose();
        RebindAim.action.Enable();
        AimButton.Select();
    }

    private void CompleteRebindSmoke()
    {
        WaitingSmokeText.SetActive(false);
        RebindSmokeText.SetActive(true);
        rebindOp.Dispose();
        RebindSmoke.action.Enable();
        SmokeButton.Select();
    }
    private void CompleteRebindInvisibility()
    {
        WaitingInvisibilityText.SetActive(false);
        RebindInvisibilityText.SetActive(true);
        rebindOp.Dispose();
        RebindInvisibility.action.Enable();
        InvisibilityButton.Select();
    }
}
