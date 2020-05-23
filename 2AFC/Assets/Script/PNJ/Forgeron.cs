using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Forgeron : MonoBehaviour
{
    public GameObject txt;

    void OnTriggerEnter(Collider other)
    {
        txt.SetActive(true);
        new WaitForSeconds(2f);
        other.gameObject.transform.GetChild(5).transform.GetChild(4).gameObject.SetActive(true);
    }


    void OnTriggerExit(Collider other)
    {
        txt.SetActive(false);
        other.gameObject.transform.GetChild(5).transform.GetChild(4).gameObject.SetActive(false);
    }
}
