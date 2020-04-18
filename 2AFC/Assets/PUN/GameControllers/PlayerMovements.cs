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



    private Vector3 _velocity;
    public float Gravity;
    public LayerMask Ground;
    private bool _isGrounded = true;
    private Transform _groundChecker;
    public float GroundDistance = 1f;
    public float JumpHeight;
    //public float JumpForce = 14f;
    public float DashDistance = 5f;
    public Vector3 Drag;



    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        PV = GetComponent<PhotonView>();
        myCC = GetComponent<CharacterController>();
        if (PV.IsMine)
        {
            playercamera.SetActive(true);
        }
        else
            playercamera.SetActive(false);


        _groundChecker = transform.GetChild(0);

    }

    void Update()
    {
        bool pause = Input.GetKeyDown(KeyCode.Escape);

        if(pause)
        {
            GameObject.Find("Pause").GetComponent<Pause>().TogglePause();
        }

        if(Pause.paused)
        {
            pause = false;
        }

        if (PV.IsMine && !Pause.paused)
        {
            BasicMovement();
            BasicRotation();
        }

        _isGrounded = Physics.CheckSphere(_groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);
        if (_isGrounded && _velocity.y < 0)
            _velocity.y = 0f;


        _velocity.y += Gravity * Time.deltaTime;
        myCC.Move(_velocity * Time.deltaTime);
        
        
        if(Input.GetKey(KeyCode.Space)&& myCC.isGrounded)
        {
            _velocity.y += Mathf.Sqrt(JumpHeight * -2f * Gravity);
            _velocity.x = Input.GetAxis("Horizontal");
            _velocity.z = Input.GetAxis("Vertical");
        }
        
        
        /*_velocity.x /= 1 + Drag.x * Time.deltaTime;
        _velocity.y /= 1 + Drag.y * Time.deltaTime;
        _velocity.z /= 1 + Drag.z * Time.deltaTime;*/

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

        

        /*if (Input.GetKey(KeyCode.LeftShift)) 
        {
            Debug.Log("Dash");
            _velocity += Vector3.Scale(transform.forward, DashDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * Drag.x + 1)) / -Time.deltaTime), 0, (Mathf.Log(1f / (Time.deltaTime * Drag.z + 1)) / -Time.deltaTime)));
        }*/

    }

    void BasicRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeed;
        transform.Rotate(new Vector3(0, mouseX, 0));
        
        float mouseY = -Input.GetAxis("Mouse Y") * Time.deltaTime * rotationSpeed;

         if (camera.position.y< transform.position.y+transform.localScale.y+5 && mouseY>0 )
         {
             camera.position += (new Vector3(0, mouseY / 15, 0));
             camera.Rotate (new Vector3( mouseY/2,0, 0)); 
         }

         if (camera.position.y >transform.position.y-transform.localScale.y+0.5 && mouseY< 0 )
         {
             camera.position += (new Vector3(0, mouseY / 15, 0));
             camera.Rotate(new Vector3( mouseY/2, 0,0));
         }
    }
}

