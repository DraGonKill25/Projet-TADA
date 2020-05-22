using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Choixdeclasse : MonoBehaviour
{
    private bool conversation;
    public TextMeshProUGUI TxtQuestion;
    public TextMeshProUGUI TxtOui;
    public TextMeshProUGUI TxtNon;
  




    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "boxbody")
        {
            TxtQuestion.gameObject.SetActive(true);
            conversation = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "boxbody")
        {
            TxtQuestion.gameObject.SetActive(false);
            conversation = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown((KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Accept"))))
        {
            TxtQuestion.gameObject.SetActive(false);
            TxtOui.gameObject.SetActive(true);
            //changer de classe
            
        }

        if (Input.GetKeyDown((KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Refuse"))))
        {
            TxtQuestion.gameObject.SetActive(false);
            TxtNon.gameObject.SetActive(true);
            new WaitForSeconds(2f);
            TxtNon.gameObject.SetActive(false);
        }
    }
}
