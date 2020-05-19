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
    */
    /*Vector3 tpLocation = new Vector3(13f, -12f, 0f);
    Quaternion startRotation = Quaternion.Euler(Vector3.zero);*/
    void OnTriggerEnter(Collider other)
    {
        /*Debug.Log("il rentre dans la fonction");
        if (other.gameObject.tag == "Player" /*|| other.gameObject.tag == "boxbody")
        {*/
            Debug.Log("il doit tp le joueur");
            //PhotonView t  est = other.gameObject.GetComponent<PhotonView>();
        GameObject player = other.gameObject;
        //player.transform.SetPositionAndRotation(tpLocation, startRotation);

        player.transform.position = TeleportTarget.transform.position;
        /*}*/

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
