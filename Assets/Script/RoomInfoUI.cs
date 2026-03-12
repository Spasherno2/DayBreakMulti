using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class RoomInfoUI : MonoBehaviour
{
    public Text roomCodeText;

    void Start()
    {
        if (PhotonNetwork.InRoom)
        {
            roomCodeText.text = "Room Code: " + PhotonNetwork.CurrentRoom.Name;
        }
    }
}