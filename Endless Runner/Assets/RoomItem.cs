using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomItem : MonoBehaviour
{
    public Text roomName;

    public void setRoomName(string _roomName)
    {
        roomName.text = _roomName;
    }
}
