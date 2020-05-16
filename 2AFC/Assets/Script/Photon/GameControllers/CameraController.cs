using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject LookAt;
    public GameObject TPVPoint;
    public GameObject Localplayer;

    private Transform myTransform;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Localplayer == null)
            GetLocalPlayer();
    }

    private void LateUpdate()
    {
        if(Localplayer != null)
        {
            if(TPVPoint == null)
            {
                TPVPoint = Localplayer.transform.GetChild(2).gameObject;
                LookAt = Localplayer.transform.GetChild(1).gameObject;
            }

            myTransform.position = TPVPoint.transform.position;
            transform.LookAt(LookAt.transform);
        }
    }

    private void GetLocalPlayer()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        Debug.Log("Number of players : " + players.Length);
        foreach(GameObject player in players)
        {
            print(player.transform.GetChild(0).gameObject.GetComponent<PhotonView>().IsMine);
            print(player.GetComponent<PhotonView>().IsMine);
            if(player.transform.GetChild(0).gameObject.GetComponent<PhotonView>().IsMine)
            {
                Debug.Log("Found the local player");
                Localplayer = player;
                break;
            }
        }
    }
}