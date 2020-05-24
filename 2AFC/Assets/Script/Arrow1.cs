using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow1 : MonoBehaviour
{
    Rigidbody mybody;
    GameObject player;
    private float lifetimer = 3f;
    private float timer;
    private bool hit = false;

    void Start()
    {
        mybody = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.LookRotation(mybody.velocity);
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (hit && timer >= lifetimer)
        {
            Destroy(gameObject);
        }

        if (!hit)
        {
            transform.rotation = Quaternion.LookRotation(mybody.velocity);
        }

    }
    private void OnCollisionEnter(Collision other)
    {


        Debug.Log(other.collider.tag);
        
        
        if (other.collider.tag != "Arrow" && other.collider.tag != "Player")
        {
           
            hit = true;
            Stick();
        }

    }
    private void Stick()
    {
        mybody.constraints = RigidbodyConstraints.FreezeAll;
    }
}
