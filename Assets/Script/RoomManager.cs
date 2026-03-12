using UnityEngine;
using Photon.Pun;

public class RoomManager : MonoBehaviour
{
    public Transform[] spawnPoints;

    private void Start()
    {PhotonNetwork.AutomaticallySyncScene = true;
        Debug.Log("RoomManager Start. InRoom = " + PhotonNetwork.InRoom);

        if (!PhotonNetwork.InRoom) return;

        int index = (PhotonNetwork.LocalPlayer.ActorNumber - 1) % spawnPoints.Length;
        Transform spawnPoint = spawnPoints[index];

        GameObject player = PhotonNetwork.Instantiate(
            "PlayerPrefab",
            spawnPoint.position,
            spawnPoint.rotation
        );

        PhotonView pv = player.GetComponent<PhotonView>();
        Debug.Log("Spawned " + player.name + " ViewID=" + pv.ViewID + " IsMine=" + pv.IsMine);
    }
}