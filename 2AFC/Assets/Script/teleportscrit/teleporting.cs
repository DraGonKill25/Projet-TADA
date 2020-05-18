using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class teleporting : MonoBehaviour
{
    public Transform TeleportTarget;
    public Transform Letp;
    private float distance;
    /*public GameObject[] players;
    public Photon.Realtime.Player test;
    public GameObject Playerdebase;
    void Update()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        Photon.Realtime.Player[] test = PhotonNetwork.PlayerList;
        

        foreach (GameObject player in players)
        {
            Playerdebase = player;
            Transform Target = player.transform;
            distance = Vector3.Distance(Target.position, Letp.position);

            if (distance < 2)
            {
                Debug.Log("il doit tp le player");
                player.transform.position = TeleportTarget.transform.position;
            }
        }

    }*/
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("il trouve le collider");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("il doit tp le player");
            //other.transform.parent.gameObject
        }

       /* GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject player in players)
        {
            Debug.Log("il rentre dans la fonction");
            Transform Target = player.transform;
            distance = Vector3.Distance(Target.position, Letp.position);

            if (distance < 3)
            {
                Debug.Log("il doit tp le player");
                player.transform.position = TeleportTarget.transform.position;
            }
        }

        //Playerdebase.transform.position = TeleportTarget.transform.position;*/
    }
}
