using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public GameObject fire;
    public GameObject fire2;
    public Transform spawn;
    public Transform spawn2;
    public float shootforce = 50f;
    private bool special = true;
  
    private float timer2;
   


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown((KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Action_1"))))
        {
            GameObject fleche = Instantiate(fire, spawn.position, Quaternion.identity);
            Rigidbody rb = fleche.GetComponent<Rigidbody>();
            rb.velocity = player.transform.forward * shootforce;
        }
        if (Input.GetKeyDown((KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Action_2"))) && special)
        {
            GameObject fleche = Instantiate(fire2, spawn2.position, Quaternion.identity);
            Rigidbody rb = fleche.GetComponent<Rigidbody>();
            rb.velocity = -player.transform.up * shootforce;
            special = false;
        }
        else if (!special)
        {
            timer2 += Time.deltaTime;
            if (timer2 >= 15f)
            {
                special = true;
                timer2 = 0;
            }
        }
    }
}
