using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Villageois : MonoBehaviour
{
    private bool conversation;
    public TextMeshProUGUI TxtSalut;
    


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "boxbody")
        {
            TxtSalut.gameObject.SetActive(true);
            conversation = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "boxbody")
        {
            TxtSalut.gameObject.SetActive(false);
            conversation = false;
        }
    }
   
}
    // Update is called once per frame
   
