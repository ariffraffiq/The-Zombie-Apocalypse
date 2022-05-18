using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class PlayerCount : MonoBehaviour
{
    public int playerCount, roomSize;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayerCountUpdate()
    {
        playerCount = PhotonNetwork.PlayerList.Length;

        if (playerCount == 1)
        {
            SceneManager.LoadScene("Multiplayer");
        }
    }
}
