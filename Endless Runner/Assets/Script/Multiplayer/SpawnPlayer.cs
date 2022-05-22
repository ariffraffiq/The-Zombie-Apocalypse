using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject player1,player2, player3, player4;
    public Transform[] spawn;
    public int charNum;
    // Start is called before the first frame update
    void Start()
    {
        int randomNumber = Random.Range(0, spawn.Length);
        Transform spawns = spawn[randomNumber];
        charNum = CharacterSelection.currentCharacter;

        if (charNum == 0)
        {
            PhotonNetwork.Instantiate(player1.name, spawn[0].position, Quaternion.identity);
            //PhotonNetwork.Instantiate(player1.name, spawns.position, Quaternion.identity);
        }

          if (charNum == 1)
        {
            PhotonNetwork.Instantiate(player2.name, spawn[1].position, Quaternion.identity);
           // PhotonNetwork.Instantiate(player2.name, spawns.position, Quaternion.identity);
        }

          if (charNum == 2)
        {
            PhotonNetwork.Instantiate(player3.name, spawn[2].position, Quaternion.identity);
            //PhotonNetwork.Instantiate(player3.name, spawns.position, Quaternion.identity);
        }

          if (charNum == 3)
        {
            PhotonNetwork.Instantiate(player4.name, spawn[3].position, Quaternion.identity);
            //PhotonNetwork.Instantiate(player4.name, spawns.position, Quaternion.identity);
        }
    }
}
