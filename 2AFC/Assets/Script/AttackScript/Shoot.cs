using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public GameObject arrow;
    public Transform spawn;
    public float shootforce = 50f;
    private bool special = true;
    private float timer;
    private float timer2;
    private float spec_time = 0.5f;

    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown((KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Action_1"))))
        {
            GameObject fleche = Instantiate(arrow, spawn.position,Quaternion.identity);
            Rigidbody rb = fleche.GetComponent<Rigidbody>();
            rb.velocity = player.transform.forward * shootforce;
        }
        if (Input.GetKey((KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Action_2"))) && special)
        {
            GameObject fleche = Instantiate(arrow, spawn.position, Quaternion.identity);
            Rigidbody rb = fleche.GetComponent<Rigidbody>();
            rb.velocity = player.transform.forward * shootforce;
            timer += Time.deltaTime;
            if(timer>=spec_time)
            {
                special = false;
                timer=0;
                
            }
           
          
        }
        else if(!special)
        {
            timer2 += Time.deltaTime;
            if ( timer2>=15f)
            {
                special = true;
                timer2 = 0;
            }
        }
    }
}
