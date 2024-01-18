using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomSpawner : MonoBehaviour
{
    public GameObject AI;
    private Vector3 randomposition;
    public float overlapRadius;
    private GameObject player;
    private int objectsInScene;
    private int layerMask2, playerMask, winTrigger;
    public int AmountOfAIToSpawn;
    private Transform[] Soldiers;
    public float radiusForAI;
    List<Vector3> usedPositions;
    private Scene scene;
    private string scene1, scene2;

    // Start is called before the first frame update
    void Start()
    {
        scene1 = "Level1";
        scene2 = "Level2";
        scene = scene = SceneManager.GetActiveScene();
        player = GameObject.FindGameObjectWithTag("Player");
        objectsInScene = 1 << 7;
        layerMask2 = 1 << 8;
        playerMask = 1 << 6;
        winTrigger = 1 << 11;
        usedPositions = new List<Vector3>(AmountOfAIToSpawn);
        SpawnAI();
    }

    void SpawnAI()
    {
        for (int i = 0; i < AmountOfAIToSpawn; i++)
        {
            GetRandomPos();
            while (Physics.CheckSphere(randomposition, overlapRadius, objectsInScene))
            {
                GetRandomPos();
            }
            while(Physics.CheckSphere(randomposition, radiusForAI, winTrigger))
            {
                GetRandomPos();
            }
            /*
            //Check if spawn point is near player
            while (Vector3.Distance(randomposition, player.transform.position) < 25)
            {
                print("Away From Player");
                GetRandomPos();
            }*/
            /*while(Vector3.Distance(player.transform.position, randomposition) < 40)
            {
                print("Near Player");
                GetRandomPos();
            }*/
            /*foreach (Vector3 currentPos in usedPositions)
            {
                while (Vector3.Distance(randomposition, currentPos) < 10)
                {
                    print("Get New POS");
                    GetRandomPos();
                }
            }*/
            GameObject[] AIs = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject soldiers in AIs)
            {
                while (Vector3.Distance(randomposition, soldiers.transform.position) < 30)
                {
                     GetRandomPos();
                }
            }
            while (Vector3.Distance(randomposition, player.transform.position) < 20)
            {
                GetRandomPos();
            }
            /*while (Vector3.Distance(randomposition, player.transform.position) < 30)
            {
                print("Away From Player");
                GetRandomPos();
            }*/
            GameObject clone = Instantiate(AI, randomposition, Quaternion.identity);
            clone.name = "AISoldier";
            usedPositions.Add(randomposition);
            
            /*
            GameObject[] Soldier = GameObject.FindGameObjectsWithTag("Enemy");//GameObject.FindObjectsOfType(typeof(Transform)) as Transform[];
            foreach(GameObject go in Soldier)
            {
                while (Vector3.Distance(randomposition, go.transform.position) < 30)
                {
                    print("Away From Other AI");
                    GetRandomPos();
                }
            }*/
        }
        //this.gameObject.SetActive(false);
    }
    void Respawn()
    {
            GetRandomPos();
            while (Physics.CheckSphere(randomposition, overlapRadius, objectsInScene))
            {
                print("Away From Objects");
                GetRandomPos();
            }
            GameObject[] AIs = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject soldiers in AIs)
            {
                while (Vector3.Distance(randomposition, soldiers.GetComponent<Transform>().position) < 10)
                {
                    print("Get New POS");
                    GetRandomPos();
                }
            }
            while (Vector3.Distance(randomposition, player.transform.position) < 10)
            {
                print("Near Player");
                GetRandomPos();
            }

            GameObject clone = Instantiate(AI, randomposition, Quaternion.identity);
            clone.name = "AISoldier";
            usedPositions.Add(randomposition);
    }

    void GetRandomPos()
    {
        if (scene.name == scene1)
        {
            randomposition = new(Random.Range(-9, 58), 0, Random.Range(-56, 24));
        }
        else if(scene.name == scene2)
        {
            randomposition = new(Random.Range(-33, 58), 0, Random.Range(-93, 22));
        }
    }
}
