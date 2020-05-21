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
        if (Input.GetKeyDown(KeyCode.O))
        {
            TxtQuestion.gameObject.SetActive(false);
            TxtOui.gameObject.SetActive(true);
            
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            TxtQuestion.gameObject.SetActive(false);
            TxtNon.gameObject.SetActive(true);
            new WaitForSeconds(2f);
            TxtNon.gameObject.SetActive(false);

        }
    }
}
