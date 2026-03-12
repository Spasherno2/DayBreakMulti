using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class LobbyUI : MonoBehaviourPunCallbacks
{
    public InputField roomCodeInput;
    public Text statusText;
    public byte maxPlayersPerRoom = 4;

    public void CreateRoom()
    {
        string roomCode = roomCodeInput.text.Trim();

        if (string.IsNullOrEmpty(roomCode))
        {
            statusText.text = "Enter room code";
            return;
        }

        RoomOptions options = new RoomOptions();
        options.MaxPlayers = maxPlayersPerRoom;

        PhotonNetwork.CreateRoom(roomCode, options);
        statusText.text = "Creating room...";
    }

    public void JoinRoomByCode()
    {
        string roomCode = roomCodeInput.text.Trim();

        if (string.IsNullOrEmpty(roomCode))
        {
            statusText.text = "Enter room code";
            return;
        }

        PhotonNetwork.JoinRoom(roomCode);
        statusText.text = "Joining room...";
    }

    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
        statusText.text = "Searching room...";
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Created room: " + PhotonNetwork.CurrentRoom.Name);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined room: " + PhotonNetwork.CurrentRoom.Name);

        statusText.text = "Joined: " + PhotonNetwork.CurrentRoom.Name;

        if (PhotonNetwork.IsMasterClient)
        {
            Debug.Log("Master loading RoomScene");
            PhotonNetwork.LoadLevel("RoomScene");
        }
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        statusText.text = "Create failed: " + message;
        Debug.Log("Create failed: " + message);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        statusText.text = "Join failed: " + message;
        Debug.Log("Join failed: " + message);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        statusText.text = "No room";
        Debug.Log("Join random failed: " + message);
    }
}