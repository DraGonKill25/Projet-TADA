using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;

public class insideTriger : MonoBehaviour
{
    public bool conversation;
    public TextMeshProUGUI TxtQuestion;
    public TextMeshProUGUI TxtReponse;
    public TextMeshProUGUI TxtErreur;
    public TextMeshProUGUI TxtNon;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            conversation = true;
            TxtQuestion.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            conversation = false;
            TxtQuestion.gameObject.SetActive(false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (conversation)
        {
            //recupere la classe du perso dans le trigger
            if(conversation /*classe a mettre normalement*/)
            {
                if (Input.GetKeyDown(KeyCode.O))
                {
                    //CHANGER DE CLASSE

                    // Affiche mon nouveau Convas
                    TxtQuestion.gameObject.SetActive(false);
                    TxtReponse.gameObject.SetActive(true);
                }

                if (Input.GetKeyDown(KeyCode.N))
                {
                    //Affiche Canvas "Revient plus tard"
                    TxtQuestion.gameObject.SetActive(false);
                    TxtNon.gameObject.SetActive(true);

                }
            }
            else
            {
                //il a deja une classe
                TxtQuestion.gameObject.SetActive(false);
                TxtErreur.gameObject.SetActive(true);
            }
             
        }
    }
}
