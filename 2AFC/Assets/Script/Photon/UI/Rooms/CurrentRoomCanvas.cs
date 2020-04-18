using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrentRoomCanvas : MonoBehaviour
{
    [SerializeField]
    private PlayerListingMenu _playerListingMenu;
    [SerializeField]
    private LeaveRoomMenu _leaveRoomMenu;

    [SerializeField]
    private GameObject _readyButton;
    [SerializeField]
    private GameObject _startButton;

    public LeaveRoomMenu LeaveRoomMenu { get { return _leaveRoomMenu; } }

    private RoomsCanvases _roomsCanvases;
    public void FirstInitialize(RoomsCanvases canvases)
    {
        _roomsCanvases = canvases;
        _playerListingMenu.FirstInitialize(canvases);
        _leaveRoomMenu.FirstInitialize(canvases);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        if (PhotonNetwork.IsMasterClient)
            _readyButton.SetActive(false);
        else
        {
            _startButton.GetComponentInChildren<TextMeshProUGUI>().color = Color.grey;
            _startButton.GetComponentInChildren<TextMeshProUGUI>().SetText("waiting");

        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
