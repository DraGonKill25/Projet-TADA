using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PhotonView PV;
    private CharacterController Player;
    private Animator MyPlayerAnimator;

    [SerializeField]
    private Rigidbody rigidbody;
    [SerializeField]
    private AudioSource audiosrc;

    [SerializeField]
    private float movementSpeed /*=2f*/;
    [SerializeField]
    private float rotationSpeed /*=30f*/;

    private bool _isGrounded = true;
    private Transform _groundChecker;
    private float GroundDistance = 1f;
    [SerializeField]
    private float JumpHeight;
    private Vector3 _velocity;
    [SerializeField]
    private float Gravity;
    private LayerMask Ground;

    //cooldown on speel and atk
    private float CooldownTime1 = 2;
    private float CooldownTime2 = 5;
    private float CooldownTime3 = 15;
    private float CooldownTimeblock = 7;
    private float nextcast1 = 0;
    private float nextcast2 = 0;
    private float nextcast3 = 0;
    private float nextcastblock = 0;

    private bool isMoving;

    public string Classe = "Apprentice";
    [HideInInspector]
    public ViePerso perso;



    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        PV = GetComponent<PhotonView>();
        Player = GetComponent<CharacterController>();
        GameObject playercamera = GameObject.Find("Camera");

        GameObject.Find("Pause").transform.GetChild(0).gameObject.SetActive(false);

        if (PV.IsMine)
            playercamera.SetActive(true);

        _groundChecker = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        MyPlayerAnimator = FindAnimator();

        if (Input.GetKey((KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Pause"))) && !Pause.paused)
            GameObject.Find("Pause").GetComponent<Pause>().TogglePause();
            
        if (PV.IsMine && !Pause.paused)
        {
            MyPlayerAnimator.SetInteger("Speed", 0);
            MyPlayerAnimator.SetInteger("Attack", 0);
            BasicMovement();
            //BasicRotation();
        }

        if (Input.GetKey((KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Cursor"))))
        {
            if (Cursor.visible == false)
                Cursor.visible = true;
            else
                Cursor.visible = false;

        }

        if (rigidbody.velocity.x != 0)
            isMoving = true;
        else
            isMoving = false;

        if (isMoving && !audiosrc.isPlaying)
            audiosrc.Play();
        else
            audiosrc.Stop();

        _isGrounded = Physics.CheckSphere(_groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);
        if (_isGrounded && _velocity.y < 0)
            _velocity.y = 0f;


        _velocity.y += Gravity * Time.deltaTime;
        Player.Move(_velocity * Time.deltaTime);


        if (Input.GetKey((KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Jump"))) && Player.isGrounded)
        {
            _velocity.y += Mathf.Sqrt(JumpHeight * -2f * Gravity);
            _velocity.x = Input.GetAxis("Horizontal");
            _velocity.z = Input.GetAxis("Vertical");
            MyPlayerAnimator.SetInteger("Attack", 5);
        }

        Debug.Log(perso.ReturnPV());
        if (perso.ReturnPV() <= 0)
        {
            MyPlayerAnimator.SetInteger("Attack", 6);
        }
        AnimatorStateInfo info = MyPlayerAnimator.GetCurrentAnimatorStateInfo(1);
        if (info.IsName("Dead"))
        {
            //DestroyObject(gameObject);
            transform.position = new Vector3(91.7f, -5.55f);
            perso.ResetHP();
        }
    }

    private void BasicMovement()
    {
        AnimatorStateInfo foo = MyPlayerAnimator.GetCurrentAnimatorStateInfo(1);
        if (Input.GetKey((KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Forward"))) &&
            !Input.GetKey((KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Action_4"))) 
            && !foo.IsName("Armature_Block "))
        {
            if (Input.GetKey((KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Run"))))
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

        if (Input.GetKey((KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Run"))) &&
            !Input.GetKey((KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Forward"))))
            MyPlayerAnimator.SetInteger("Speed", 0);

        if (Input.GetKey((KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Back"))) &&
            !Input.GetKey((KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Action_4"))) 
            && !foo.IsName("Armature_Block"))
        {
            Player.Move(-transform.forward * Time.deltaTime * movementSpeed);
            MyPlayerAnimator.SetInteger("Speed", 3);
        }


        //float h = Input.GetAxis("Mouse X");
        if (Input.GetKey((KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right"))))
            RotatePerso(1);

        if (Input.GetKey((KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left"))))
            RotatePerso(-1);


        if (Time.time > nextcast1)
        {
            if (Input.GetKey((KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Action_1"))))
            {
                MyPlayerAnimator.SetInteger("Attack", 1);
                nextcast1 = Time.time + CooldownTime1;
            }
        }
        

        if (Time.time > nextcast2)
        {
            if (Input.GetKey((KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Action_2"))))
            {
                MyPlayerAnimator.SetInteger("Attack", 2);
                nextcast2 = Time.time + CooldownTime2;
            }
        }

        if (Time.time > nextcast3)
        {
            if (Input.GetKey((KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Action_3"))))
            {
                MyPlayerAnimator.SetInteger("Attack", 3);
                nextcast3 = Time.time + CooldownTime3;
            }
        }

        if (Time.time > nextcastblock)
        {
            if (Input.GetKey((KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Action_4"))))
            {
                MyPlayerAnimator.SetInteger("Attack", 4);
                nextcastblock = Time.time + CooldownTimeblock;
            }
        }
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
        float deltaRotate = Time.deltaTime * 50f;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            deltaRotate = deltaRotate * 1.5f;
        }
        transform.Rotate(Vector3.up * deltaRotate * direction);
    }

    private Animator FindAnimator()
    {
        GameObject[] SubPlayers = GameObject.FindGameObjectsWithTag("SubPlayer");
        Animator MyCurrentAnimator = null;
        int i = 0;
        int length = SubPlayers.Length;
        while (i < length || MyCurrentAnimator == null)
        {
            if (SubPlayers[i].activeSelf)
            {
                //Debug.Log("Found Animator");
                MyCurrentAnimator = SubPlayers[i].GetComponent<Animator>();
            }

            i++;
        }

        if(MyCurrentAnimator == null)
        {
            Debug.Log("Can't find an Animator");
        }
        return MyCurrentAnimator;
    }
}