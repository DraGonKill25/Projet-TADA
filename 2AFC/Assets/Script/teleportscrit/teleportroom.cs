using System.Diagnostics.Contracts;
using TMPro;
using UnityEngine;

public class teleportroom : MonoBehaviour
{
    public Transform Next_TP;

    void OnTriggerEnter(Collider other)
    {
        GameObject player = other.gameObject;
        player.transform.position = Next_TP.transform.position;
    }
}
