﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Maire : MonoBehaviour
{
    private bool conversation;
    public TextMeshProUGUI TxtQuestion;
    public TextMeshProUGUI TxtOui;
    public TextMeshProUGUI TxtNon;
    public GameObject InvisibleWall;
    public GameObject maire;
    public GameObject pnj;



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
            InvisibleWall.SetActive(false);
            maire.gameObject.SetActive(false);
            pnj.gameObject.SetActive(true);
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
   
