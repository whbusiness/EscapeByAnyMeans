using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    private AudioSource FootstepAudioSource;

    void Start()
    {
        FootstepAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Movement.Moving)
        {
            FootstepAudioSource.enabled = true;
        }
        else
        {
            FootstepAudioSource.enabled = false;
        }
        if(Movement.HitEnemy || Movement.MissEnemy)
        {
            FootstepAudioSource.enabled = false;
        }
    }
}
