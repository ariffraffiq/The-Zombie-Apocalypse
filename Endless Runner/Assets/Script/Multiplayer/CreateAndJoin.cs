using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class CreateAndJoin : MonoBehaviourPunCallbacks
{
    public TMP_InputField  createRoom;
    public TMP_InputField  joinRoom;
    public int playerCount, roomSize;

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createRoom.text);
        SceneManager.LoadScene("Multiplayer");
       // playerCount++;
        //PlayerCountUpdate();
    }

    public void JoinedRoom()
    {
        PhotonNetwork.JoinRoom(joinRoom.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Multiplayer");
    }

    void PlayerCountUpdate()
    {
        playerCount = PhotonNetwork.PlayerList.Length;
        

        if (playerCount == 2)
        {
            SceneManager.LoadScene("Multiplayer");
        }
    }
}
