using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrollerApprentie : MonoBehaviour
{
    private PhotonView PV;
    private CharacterController Player;
    private Animator MyPlayerAnimator;

    public float movementSpeed /*=2f*/;
    public float rotationSpeed /*=30f*/;

    private bool _isGrounded = true;
    private Transform _groundChecker;
    public float GroundDistance = 1f;
    public float JumpHeight;
    private Vector3 _velocity;
    public float Gravity;
    public LayerMask Ground;
    
    //cooldown on speel and atk
    public float CooldownTime1 = 8;
    public float CooldownTime2 = 12;
    private float nextcast1 = 0;
    private float nextcast2 = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        PV = GetComponent<PhotonView>();
        Player = GetComponent<CharacterController>();
        MyPlayerAnimator = transform.GetChild(1).gameObject.GetComponent<Animator>();
        GameObject playercamera = GameObject.Find("Camera");

        GameObject.Find("Pause").transform.GetChild(0).gameObject.SetActive(false);

        if (MyPlayerAnimator == null)
        {
            Debug.LogError("Erreur pour trouver l'objet");
        }
        else
        {
            if (PV.IsMine)
                playercamera.SetActive(true);
        }

        _groundChecker = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        bool pause = Input.GetKeyDown(KeyCode.Escape);

        if (pause)
            GameObject.Find("Pause").GetComponent<Pause>().TogglePause();

        if (Pause.paused)
            pause = false;

        if (PV.IsMine && !Pause.paused)
        {
            MyPlayerAnimator.SetInteger("Speed", 0);
            BasicMovement();
            //BasicRotation();
        }

        if (Input.GetKey(KeyCode.M))
        {
            if (Cursor.visible == false)
                Cursor.visible = true;
            else
                Cursor.visible = false;
            
        }
        
        _isGrounded = Physics.CheckSphere(_groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);
        if (_isGrounded && _velocity.y < 0)
            _velocity.y = 0f;
            

        _velocity.y += Gravity * Time.deltaTime;
        Player.Move(_velocity * Time.deltaTime);


        if (Input.GetKey(KeyCode.Space) && Player.isGrounded)
        {
            _velocity.y += Mathf.Sqrt(JumpHeight * -2f * Gravity);
            _velocity.x = Input.GetAxis("Horizontal");
            _velocity.z = Input.GetAxis("Vertical");
        }
    }

    private void BasicMovement()
    {
        //AnimatorStateInfo foo = MyPlayerAnimator.GetCurrentAnimatorStateInfo(1);
        if (Input.GetKey(KeyCode.Z) /*&& !Input.GetKey(KeyCode.F) && !foo.IsName("Armature_Block")*/)
        {
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.Z))
            {
                Player.Move(transform.forward * Time.deltaTime * movementSpeed * 2);
                MyPlayerAnimator.SetInteger("Speed", 2);
            }
            else
            {
                Player.Move(transform.forward * Time.deltaTime * movementSpeed);
                MyPlayerAnimator.SetInteger("Speed", 1);
            }
        }

        if (Input.GetKey(KeyCode.S) /*&& !Input.GetKey(KeyCode.F) && !foo.IsName("Armature_Block")*/)
        {
            Player.Move(-transform.forward * Time.deltaTime * movementSpeed);
            MyPlayerAnimator.SetInteger("Speed", 3);
        }


        //float h = Input.GetAxis("Mouse X");
        if (Input.GetKey(KeyCode.D))
            RotatePerso(1);

        if (Input.GetKey(KeyCode.Q))
            RotatePerso(-1);
        

        if(Time.time > nextcast1)
        {
            if (Input.GetKey(KeyCode.A))
            {
                MyPlayerAnimator.SetInteger("Attack", 1);
                nextcast1 = Time.time + CooldownTime1;
            }
        }
        
        if (Time.time > nextcast2)
        {
            if (Input.GetKey(KeyCode.E))
            {
                MyPlayerAnimator.SetInteger("Attack", 2);
                nextcast2 = Time.time + CooldownTime2;
            }
        }
        /*
        if (Time.time > nextcast3)
        {
            if (Input.GetKey(KeyCode.R))
            {
                MyPlayerAnimator.SetInteger("Attack", 3);
                nextcast3 = Time.time + CooldownTime3;
            }
        }

        if (Time.time > nextcastblock)
        {
            if (Input.GetKey(KeyCode.F))
            {
                MyPlayerAnimator.SetInteger("Attack", 4);
                nextcastblock = Time.time + CooldownTimeblock;
            }
        }*/
    }

    void BasicRotation()
    {
        GameObject playercamera = GameObject.Find("Camera");
        Transform camera = playercamera.transform;

        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeed;
        transform.Rotate(new Vector3(0, mouseX, 0));

        float mouseY = -Input.GetAxis("Mouse Y") * Time.deltaTime * rotationSpeed;

        if (camera.position.y < transform.localScale.y + 5 && mouseY > 0)
        {
            camera.position += (new Vector3(0, mouseY / 15, 0));
            camera.Rotate(new Vector3(mouseY / 2, 0, 0));
        }

        if (camera.position.y > transform.position.y - transform.localScale.y + 1 && mouseY < 0)
        {
            camera.position += (new Vector3(0, mouseY / 15, 0));
            camera.Rotate(new Vector3(mouseY / 2, 0, 0));
        }
    }

    private void RotatePerso(int direction)
    {
        float deltaRotate = Time.deltaTime * 20f * 2;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            deltaRotate = deltaRotate * 2;
        }
        transform.Rotate(Vector3.up * deltaRotate * direction);
    }
}