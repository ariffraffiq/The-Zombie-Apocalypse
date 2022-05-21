using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject player1,player2, player3, player4;
    public Transform[] spawn;
    public int charNum;
    public float minX, maxX, minY, maxY;
    // Start is called before the first frame update
    void Start()
    {
        int randomNumber = Random.Range(0, spawn.Length);
        Transform spawns = spawn[randomNumber];
        charNum = CharacterSelection.currentCharacter;

        if (charNum == 0)
        {
            PhotonNetwork.Instantiate(player1.name, spawns.position, Quaternion.identity);
        }

          if (charNum == 1)
        {
            PhotonNetwork.Instantiate(player2.name, spawns.position, Quaternion.identity);
        }

          if (charNum == 2)
        {
            PhotonNetwork.Instantiate(player3.name, spawns.position, Quaternion.identity);
        }

          if (charNum == 3)
        {
            PhotonNetwork.Instantiate(player4.name, spawns.position, Quaternion.identity);
        }


       
        //player.transform.position = spawn.transform.position;
        //PhotonNetwork.Instantiate(player.name, new Vector3(-9, 0,-18), Quaternion.identity); 
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
