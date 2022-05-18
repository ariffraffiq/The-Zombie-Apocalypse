using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    public GameObject onserver,offServer;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster() 
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        //SceneManager.LoadScene("MainMenu");
        Debug.Log("Connected to server");
        offServer.gameObject.SetActive(false);
        onserver.gameObject.SetActive(true);

    } 
}
