using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class GetControls : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;
    [SerializeField] TextMeshProUGUI MoveTxt, AimTxt, LookTxt, SmokeTxt, InvisibilityTxt, SlowWalkTxt;
    // Start is called before the first frame update
    void Update()
    {
        var action = playerInput.actions.FindAction("Move");
        var movement = action.GetBindingDisplayString(action.GetBindingIndex(playerInput.currentControlScheme));
        var action2 = playerInput.actions.FindAction("Aim");
        var Aim = action2.GetBindingDisplayString(action2.GetBindingIndex(playerInput.currentControlScheme));
        var action3 = playerInput.actions.FindAction("Look");
        var Look = action3.GetBindingDisplayString(action3.GetBindingIndex(playerInput.currentControlScheme));
        var action4 = playerInput.actions.FindAction("Smoke");
        var Smoke = action4.GetBindingDisplayString(action4.GetBindingIndex(playerInput.currentControlScheme));
        var action5 = playerInput.actions.FindAction("Invisibility");
        var Invisibility = action5.GetBindingDisplayString(action5.GetBindingIndex(playerInput.currentControlScheme));
        var action6 = playerInput.actions.FindAction("SlowWalk");
        var SlowWalk = action6.GetBindingDisplayString(action6.GetBindingIndex(playerInput.currentControlScheme));
        MoveTxt.SetText("Move: " + movement);
        AimTxt.SetText("Aim: " + Aim);
        LookTxt.SetText("Look: " + Look);
        SmokeTxt.SetText("Smoke: " + Smoke);
        InvisibilityTxt.SetText("Invisibility: " + Invisibility);
        SlowWalkTxt.SetText("SlowWalk: " + SlowWalk);
    }
}
