using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class RoomManager : MonoBehaviourPunCallbacks
{
    List<string> player = new List<string>();  // to identify player is ready or not
    public GameObject playerItem;
    public Transform playerItemParent;
    public Text RoomName;

    void Start()
    {
        updatePlayerList();
        RoomName.text = "Room Name: " + PhotonNetwork.CurrentRoom.Name;
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        updatePlayerList();
        base.OnPlayerEnteredRoom(newPlayer);
        Debug.Log("Current room player: " + PhotonNetwork.CurrentRoom.PlayerCount);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        updatePlayerList();
        player.Remove(otherPlayer.NickName);
        base.OnPlayerLeftRoom(otherPlayer);
        Debug.Log("Current room player: " + PhotonNetwork.CurrentRoom.PlayerCount);
    }

    public void addReadyPlayer(string _player){
        player.Add(_player);
        updatePlayerList();
    }

    public void onClickleftRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        SceneManager.LoadScene("MainMenu");
    }

    public void updatePlayerList()
    {
        foreach (Transform child in playerItemParent)
        {
            Destroy(child.gameObject);
        }
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            Instantiate(playerItem, playerItemParent).transform.Find("Text").GetComponent<Text>().text = player.NickName;
        }
        foreach (Transform child in playerItemParent)
        {
            foreach(string p in player){
                Debug.Log(p);
                Debug.Log(child.transform.Find("Text").GetComponent<Text>().text);
                if(child.transform.Find("Text").GetComponent<Text>().text==p){
                    child.transform.Find("NotReady").gameObject.SetActive(false);
                    child.transform.Find("Ready").gameObject.SetActive(true);
            }
            }
            
        }
        
    }
}
