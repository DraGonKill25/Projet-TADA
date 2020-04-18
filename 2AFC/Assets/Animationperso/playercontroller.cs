using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public int Speed = 5;
    private Vector3 Deplacement = Vector3.zero;
    private CharacterController Player;
    public int Sensi = 10;
    public int Jump = 5;
    public int Gravity = 20;
    private Animator Anim;
    public int RunSpeed = 10;

    //cooldown on speel and atk
    public float CooldownTime1 = 2;
    public float CooldownTime2 = 5;
    public float CooldownTime3 = 15;
    public float CooldownTimeblock = 7;
    private float nextcast1 = 0;
    private float nextcast2 = 0;
    private float nextcast3 = 0;
    private float nextcastblock = 0;


    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<CharacterController>();
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Deplacement.z = Input.GetAxisRaw("Vertical");
        Deplacement.x = Input.GetAxisRaw("Horizontal");
        Deplacement = transform.TransformDirection(Deplacement);
        
        //
        //Deplacement
        //
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Player.Move(Deplacement * Time.deltaTime * RunSpeed);
        }
        else
        {
            Player.Move(Deplacement * Time.deltaTime * Speed);
        }
        
        transform.Rotate(0, Input.GetAxisRaw("Mouse X")* Sensi, 0);

        //
        //saut
        //
        if (Input.GetKeyDown(KeyCode.Space) && Player.isGrounded && !Input.GetKeyDown(KeyCode.LeftShift))
        {
            Deplacement.y = Jump;
            Anim.SetTrigger("Jump1");
        }
        if(Input.GetKeyDown(KeyCode.Space) && Player.isGrounded && Input.GetKeyDown(KeyCode.LeftShift))
        {
            Deplacement.y = Jump;
            Anim.SetTrigger("Jump2");
        }

        //
        //Gravite
        //
        if (!Player.isGrounded)
        {
            Deplacement.y -= Gravity * Time.deltaTime;
        }

        //
        //Animation
        //
        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift))
        {
            Anim.SetBool("Walk", true);
            Anim.SetBool("Run", false);
            Anim.SetBool("Back", false);
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            Anim.SetBool("Walk", true);
            Anim.SetBool("Run", true);
            Anim.SetBool("Back", false);
        }

        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            Anim.SetBool("Walk", false);
            Anim.SetBool("Run", false);
            Anim.SetBool("Back", false);
        }

        if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
        {
            Anim.SetBool("Walk", false);
            Anim.SetBool("Run", false);
            Anim.SetBool("Back", true);
        }

        if (Time.time > nextcast1)
        {
            if (Input.GetKey(KeyCode.Alpha1))
            {                    
                Anim.SetTrigger("ATK1");
                nextcast1 = Time.time + CooldownTime1;
                
            }
        }

        if (Time.time > nextcast2)
        {
            if (Input.GetKey(KeyCode.Alpha2))
            {
                Anim.SetTrigger("ATK2");
                nextcast2 = Time.time + CooldownTime2;
            }
        }

        if (Time.time > nextcast3)
        {
            if (Input.GetKey(KeyCode.Alpha3))
            {   
                Anim.SetTrigger("ATK3");
                nextcast3 = Time.time + CooldownTime3;
            }
        }

        if (Time.time > nextcastblock)
        {
            if (Input.GetMouseButton(1))
            {
                Anim.SetTrigger("Block");
                nextcastblock = Time.time + CooldownTimeblock;
            }
        }
    }
}
