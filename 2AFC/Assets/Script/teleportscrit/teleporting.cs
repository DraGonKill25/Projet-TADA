using System.Diagnostics.Contracts;
using TMPro;
using UnityEngine;

public class teleporting : MonoBehaviour
{
    public Transform Next_TP;
    public TextMeshProUGUI TxtQuestion;
    private bool conversation;
    private GameObject toto;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("il rentre en collision");
        toto = other.gameObject;
        conversation = true;
        TxtQuestion.gameObject.SetActive(true);
    }

    void OnTriggerExit(Collider other)
    {
        //toto = null;
        conversation = false;
        TxtQuestion.gameObject.SetActive(false);
    }

    void Update()
    {
        if (conversation && toto != null)
        {
            Debug.Log("conv + toto");
            if (Input.GetKeyDown((KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Accept"))))
            {
                GameObject player = toto;
                player.transform.position = Next_TP.transform.position;
            }
        }    
    }
}
