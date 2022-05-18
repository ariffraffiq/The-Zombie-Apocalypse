using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject player, spawn;
    public float minX, maxX, minY, maxY;
    // Start is called before the first frame update
    void Start()
    {
        player.transform.position = spawn.transform.position;
        PhotonNetwork.Instantiate(player.name, new Vector3(-9, 0,-18), Quaternion.identity); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
