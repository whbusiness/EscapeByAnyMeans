using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSounds : MonoBehaviour
{
    public AudioSource swordHit, swordMiss, knifeThrow;
    private bool playHit, playMiss, throwKnife;
    private void Start()
    {
        playHit = true;
        playMiss = true;
        throwKnife = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Movement.HitEnemy)
        {
            if (playHit)
            {
                StartCoroutine(nameof(PlayHit), 0.5f);
                playHit = false;
            }
        }
        if (Movement.MissEnemy)
        {
            if (playMiss)
            {
                StartCoroutine(nameof(PlayMiss), 0.5f);
                playMiss = false;
            }
        }
        if (ThrowingKnife.KnifeThrown)
        {
            if (throwKnife)
            {
                StartCoroutine(nameof(PlayKnife), 0.5f);
                throwKnife = false;
            }
        }
    }
    IEnumerator PlayHit(float delay)
    {
        swordHit.enabled = true;
        yield return new WaitForSeconds(delay);
        Movement.HitEnemy = false;
        swordHit.enabled = false;
        playHit = true;
    }
    IEnumerator PlayMiss(float delay)
    {
        swordMiss.enabled = true;
        yield return new WaitForSeconds(delay);
        Movement.MissEnemy = false;
        swordMiss.enabled = false;
        playMiss = true;
    }
    IEnumerator PlayKnife(float delay)
    {
        knifeThrow.enabled = true;
        yield return new WaitForSeconds(delay);
        ThrowingKnife.KnifeThrown = false;
        knifeThrow.enabled = false;
        throwKnife = true;
    }
}
