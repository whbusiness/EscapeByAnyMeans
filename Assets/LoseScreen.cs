using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LoseScreen : MonoBehaviour
{

    public Button restartBtn;
    public static GameObject EndGameOverlay;
    private GameObject eventSystem;
    private float time = 1f;
    private bool runOnce = true;
    private EventSystem eventSystemSystem;
    private void Awake()
    {
        time = 1;
        runOnce = true;
        EndGameOverlay = GameObject.Find("EndScenePanel");
        eventSystem = GameObject.Find("EventSystem");
        eventSystemSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        restartBtn = GameObject.Find("Restart Level btn").GetComponent<Button>();
    }

    private void Start()
    {
        EndGameOverlay.SetActive(false);

    }

    void Update()
    {
        if (LineofSight.Lost)
        {
            if (runOnce)
            {
                StartCoroutine(nameof(DisableEventSystem), 0.5f);
                runOnce = false;
            }
           /* print(time);
            time -= Time.deltaTime;
            if(time <= 0)
            {
                eventSystem.SetActive(true);
            }
            else
            {
                eventSystem.SetActive(false);
            }*/
            EndGameOverlay.SetActive(true);
            Movement.Moving = false;
            Destroy(GetComponent<LineofSight>());
            GameObject Player = GameObject.FindGameObjectWithTag("Player");
            Player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            Player.GetComponent<Rigidbody>().freezeRotation = true;
            Destroy(Player.GetComponent<Movement>());
            Destroy(Player.GetComponent<Animator>());
            Destroy(Player.GetComponent<ThrowingKnife>());
            Destroy(Player.GetComponent<SmokeBomb>());
            Destroy(Player.GetComponent<LineRenderer>());
        }
        else
        {
            EndGameOverlay.SetActive(false);
        }
    }

    IEnumerator DisableEventSystem(float delay)
    {
        //eventSystem.SetActive(false);
        yield return new WaitForSeconds(delay);
        //eventSystem.SetActive(true);
        eventSystemSystem.SetSelectedGameObject(restartBtn.gameObject);
        print("SELECT RESTART BUTTON");
    }
}
