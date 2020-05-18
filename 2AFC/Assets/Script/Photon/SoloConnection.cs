using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoloConnection : MonoBehaviour
{
    [SerializeField]
    GameObject Button;
    private void OnButtonClicked()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("We are now connected to the " + PhotonNetwork.CloudRegion + " server");
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.CurrentRoom.IsOpen = false;
        PhotonNetwork.CurrentRoom.IsVisible = false;
        PhotonNetwork.SendRate = 40; //Default 20
        PhotonNetwork.SerializationRate = 40; //Default 10
        PhotonNetwork.GameVersion = MasterManager.GameSettings.GameVersion;
        PhotonNetwork.LoadLevel(2);
    }
}
