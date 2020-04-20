using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class teleporting : MonoBehaviour
{
    public Transform TeleportTarget;
    public GameObject Player;
    
    

    void OnTriggerEnter(Collider other)
    {
        Photon.Realtime.Player[] test = PhotonNetwork.PlayerList;
        int l = test.Length - 1;

        Player.transform.position = TeleportTarget.transform.position;
    }
}
