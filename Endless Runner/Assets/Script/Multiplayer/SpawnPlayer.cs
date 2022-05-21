using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject[] player;
    public Transform[] spawn;
    public float minX, maxX, minY, maxY;
    // Start is called before the first frame update
    void Start()
    {
        int randomNumber = Random.Range(0, spawn.Length);
        Transform spawns = spawn[randomNumber];
        GameObject playerToSpawn = player [(int) PhotonNetwork.LocalPlayer.CustomProperties["playerAvatar"]];
        //player.transform.position = spawn.transform.position;
        //PhotonNetwork.Instantiate(player.name, new Vector3(-9, 0,-18), Quaternion.identity); 
        PhotonNetwork.Instantiate(playerToSpawn.name, spawns.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
