using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeCollisionCheck : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Movement.EnemysKilled++;
            ThrowingKnife.AmountOfKnives++;
            Movement.TotalKillsDuringGameplay++;
            PlayerPrefs.SetInt("TotalKills", Movement.TotalKillsDuringGameplay);
            Movement.EnemyKilledTxt.text = "Enemys Killed: " + Movement.EnemysKilled.ToString();
            Destroy(gameObject);
        }
    }
}
