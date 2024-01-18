using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    private GameObject player;
    private Transform CMVCAM;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        CMVCAM = GameObject.Find("CM vcam1").GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new(player.transform.position.x, 15, player.transform.position.z);
        transform.eulerAngles = new Vector3(90, player.transform.eulerAngles.y, 0);
    }
}
