using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestConnect : MonoBehaviourPunCallbacks
{
    [SerializeField]
    public GameObject _PlayerNameInputUI;

    private void Start()
    {
        _PlayerNameInputUI.SetActive(true);
        print("Connecting to server...");
        PhotonNetwork.SendRate = 40; //Default 20
        PhotonNetwork.SerializationRate = 40; //Default 10
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = MasterManager.GameSettings.GameVersion;
        
    }

    public override void OnConnectedToMaster()
    {
        print(PhotonNetwork.LocalPlayer.NickName + " connected to server.");

        if (!PhotonNetwork.InLobby)
            PhotonNetwork.JoinLobby();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        print("Disconnected from server for reason: " + cause.ToString());
    }
}
