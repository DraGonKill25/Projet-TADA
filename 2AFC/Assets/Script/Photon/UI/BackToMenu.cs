using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    [SerializeField]
    public GameObject _roomsUI;

    [SerializeField]
    public GameObject _PlayerNameInputUI;

    public void OnBackButtonClicked()
    {
        Debug.Log("BackButton clicked");
        _roomsUI.SetActive(false);
        _PlayerNameInputUI.SetActive(true);
        if(PhotonNetwork.InRoom)
            PhotonNetwork.LeaveRoom();
        if (PhotonNetwork.IsConnected)
            PhotonNetwork.Disconnect();
        SceneManager.LoadScene(0); //loadScene"playmutlti"
    }
}
