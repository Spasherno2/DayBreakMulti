using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public Transform[] spawnPoints;
    GameObject player = null;
    private void Start()
    {
        
        Debug.Log("RoomManager Start. InRoom = " + PhotonNetwork.InRoom);

    }

    private void Update()
    {
        if (!PhotonNetwork.InRoom) return;
        if (player == null)
        {
        
        int index = (PhotonNetwork.LocalPlayer.ActorNumber - 1) % spawnPoints.Length;
        Transform spawnPoint = spawnPoints[index];

        player = PhotonNetwork.Instantiate(
            "PlayerPrefab",
            spawnPoint.position,
            spawnPoint.rotation
        );

        PhotonView pv = player.GetComponent<PhotonView>();
        Debug.Log("Spawned " + player.name + " ViewID=" + pv.ViewID + " IsMine=" + pv.IsMine);
    }
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("RM Joined room: " + PhotonNetwork.CurrentRoom.Name);

        //statusText.text = "RM Joined: " + PhotonNetwork.CurrentRoom.Name;


    }


   

    

}