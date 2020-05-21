using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Premierequete : MonoBehaviour
{
    private bool conversation;
    public TextMeshProUGUI TxtQuestion;
    public TextMeshProUGUI TxtOui;
    public TextMeshProUGUI TxtNon;
    public GameObject InvisibleWall;
    public TextMeshProUGUI NoKill;
    public GameObject LePNJ;


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "boxbody")
        {
            TxtQuestion.gameObject.SetActive(true);
            conversation = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "boxbody")
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
            InvisibleWall.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            InvisibleWall.SetActive(false);
            StartCoroutine(WaitForKill());
            
            if (Input.GetKeyDown(KeyCode.A))
            {
                new WaitForSeconds(1f);
                TxtNon.gameObject.SetActive(false);
                LePNJ.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                //lui donner un bonus
                TxtNon.gameObject.SetActive(false);
                NoKill.gameObject.SetActive(true);
                new WaitForSeconds(2f);
                NoKill.gameObject.SetActive(false);
                LePNJ.SetActive(false);
            }

        }
    }

    IEnumerator WaitForKill()
    {
        conversation = false;
        yield return new WaitForSeconds(3f);
        TxtQuestion.gameObject.SetActive(false);
        TxtNon.gameObject.SetActive(true);
    }
}
