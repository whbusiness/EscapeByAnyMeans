using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSmokeBomb : MonoBehaviour
{
    public static bool InSmoke = false;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            InSmoke = true;
            //Movement.thisColour.a = Movement.InvisibilityAlpha;
            Movement.PlayerIsInvisible = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            InSmoke = false;
            //Movement.thisColour.a = 1;
            Movement.PlayerIsInvisible = false;
        }
    }
}
