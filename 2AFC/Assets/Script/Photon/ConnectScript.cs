using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class ConnectScript : MonoBehaviourPunCallbacks
{
    [SerializeField]
    public TextMeshProUGUI _nickname;

    [SerializeField]
    public GameObject _RoomsUI;

    [SerializeField]
    public GameObject _connectButton;

    [SerializeField]
    public GameObject _PlayerNameInputUI;

    public void OnConnectButtonClicked()
    {
        PhotonNetwork.NickName = _nickname.text;
        Debug.Log("ConnectButton clicked");
        _PlayerNameInputUI.SetActive(false);
        _RoomsUI.SetActive(true);
        PhotonNetwork.ConnectUsingSettings();
    }
}
