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
    public GameObject mainPanel;
    public GameObject roomPanel;
    public Text roomName;

    private void Start()
    {
        PhotonNetwork.JoinLobby();
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createRoom.text);
        //SceneManager.LoadScene("Lobby");
       // playerCount++;
        //PlayerCountUpdate();
    }

    public void JoinedRoom()
    {
        PhotonNetwork.JoinRoom(joinRoom.text);
    }

    public override void OnJoinedRoom()
    {
        mainPanel.SetActive(false);
        roomPanel.SetActive(true);
        roomName.text = "Room Name: " + PhotonNetwork.CurrentRoom.Name;
        //PhotonNetwork.LoadLevel("Lobby");
    }

    void PlayerCountUpdate()
    {
        playerCount = PhotonNetwork.PlayerList.Length;
        

        if (playerCount == 2)
        {
            //SceneManager.LoadScene("Lobby");
        }
    }
}
