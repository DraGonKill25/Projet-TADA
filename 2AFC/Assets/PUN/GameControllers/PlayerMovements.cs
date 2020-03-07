using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    private PhotonView PV;
    private CharacterController myCC;
    public float movementSpeed;
    public float rotationSpeed;
    public GameObject playercamera;
    public Transform camera;

    void Start()
    {
        Cursor.visible = false;
        PV = GetComponent<PhotonView>();
        myCC = GetComponent<CharacterController>();
        if (PV.IsMine)
        {
            playercamera.SetActive(true);
        }
        else
            playercamera.SetActive(false);

    }

    void Update()
    {
        if (PV.IsMine)
        {
            BasicMovement();
            BasicRotation();
        }
    }

    void BasicMovement()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            myCC.Move(transform.forward * Time.deltaTime * movementSpeed);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            myCC.Move(-transform.right * Time.deltaTime * movementSpeed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            myCC.Move(-transform.forward * Time.deltaTime * movementSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            myCC.Move(transform.right * Time.deltaTime * movementSpeed);
        }
    }

    void BasicRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeed;
        transform.Rotate(new Vector3(0, mouseX, 0));
        
        float mouseY = -Input.GetAxis("Mouse Y") * Time.deltaTime * rotationSpeed;

         if (camera.position.y<4 && mouseY>0 )
         {
             camera.position += (new Vector3(0, mouseY / 15, 0));
             camera.Rotate (new Vector3( mouseY/2,0, 0)); 
         }

         if (camera.position.y >0 && mouseY< 0 )
         {
             camera.position += (new Vector3(0, mouseY / 15, 0));
             camera.Rotate(new Vector3( mouseY/2, 0,0));
         }
    }
}

