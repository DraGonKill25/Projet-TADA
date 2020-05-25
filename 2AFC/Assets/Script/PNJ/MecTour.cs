using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Script;

public class MecTour : MonoBehaviour
{
    private bool conversation;
    public TextMeshProUGUI TxtOui;
    public TextMeshProUGUI TxtNon;
    public GameObject invisibleWall;

    private void OnTriggerEnter(Collider other)
    {
        PlayerStats stat = other.gameObject.GetComponent<PlayerStats>();
        if (stat.ChangedClass)
        {
            //peut changer de classe
            if (stat.classe.Name != "Aventurier")
            {
                TxtOui.gameObject.SetActive(true);
                invisibleWall.SetActive(false);
            }
            else
            {
                TxtNon.gameObject.SetActive(true);
                invisibleWall.SetActive(true);
            }
        }
    }
}
