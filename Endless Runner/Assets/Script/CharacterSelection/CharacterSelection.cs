using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class CharacterSelection : MonoBehaviour
{
    public RoomManager roomManager;
    public GameObject[] character;
    public GameObject SelectButton;
    public GameObject leftButton;
    public GameObject RightButton;
    public Transform playerItemParent;

    public GameObject StartButton;
    public GameObject notAvailableText;
    public GameObject selectedText;
    public int currentCharacter = 0;
    public int playerReady = 0;
    public static int ChoosedCharacter;
    public bool[] characterSelected = new bool[4];
    private bool donePicked = false;
    private PhotonView photonView;


    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        for (int i = 0; i < 4; i++)
        {
            characterSelected[i] = false;
        }
    }

    private void Update()
    {
        if (!characterSelected[currentCharacter] && !donePicked)
        {
            SelectButton.SetActive(true);
            notAvailableText.SetActive(false);
        }
        else
        {
            if (donePicked)
            {
                selectedText.SetActive(true);
            }
            else
            {
                notAvailableText.SetActive(true);
            }
            SelectButton.SetActive(false);
        }
        if (playerReady == PhotonNetwork.CurrentRoom.PlayerCount && PhotonNetwork.IsMasterClient)
        {
            StartButton.SetActive(true);
        }
    }

    public void clickRightBtn()
    {
        character[currentCharacter].SetActive(false);
        currentCharacter += 1;
        if (currentCharacter == 4)
        {
            currentCharacter = 0;
        }
        character[currentCharacter].SetActive(true);
    }

    public void clickLeftBtn()
    {
        character[currentCharacter].SetActive(false);
        currentCharacter -= 1;
        if (currentCharacter < 0)
        {
            currentCharacter = 3;
        }
        character[currentCharacter].SetActive(true);
    }

    public void selectCharacter()
    {
        donePicked = true;
        leftButton.SetActive(false);
        RightButton.SetActive(false);
        ChoosedCharacter = currentCharacter;
        characterSelected[currentCharacter] = true;
        
        character[currentCharacter].GetComponentInChildren<Animator>().enabled=true;
        photonView.RPC("UpdateCharacterChoice", RpcTarget.AllBuffered, currentCharacter, PhotonNetwork.NickName);
    }

    public void StartGame()
    {
        PhotonNetwork.LoadLevel("Multiplayer");
    }
    [PunRPC]
    void UpdateCharacterChoice(int index, string nickname)
    {
        roomManager.addReadyPlayer(nickname);
        characterSelected[index] = true;
        playerReady += 1;
        Debug.Log("runing RPC");
    }
}
