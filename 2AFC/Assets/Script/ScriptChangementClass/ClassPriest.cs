using Script;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassPriest : MonoBehaviour
{
    //
    //Warrior
    //

    public Items.Items item;
    public Class.Class classe;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            PlayerStats stat = other.gameObject.GetComponent<PlayerStats>();
            if(stat.ChangedClass)
            {
                //peut changer de classe
                if(stat.classe.Name != "Aventurier")
                {
                    //afficher canvas erreur de classe
                }
                else
                {
                    stat.classe = classe;
                    stat.item = item;
                    //afficher message de bienvenue dans la classe
                    other.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                    other.gameObject.transform.GetChild(1).gameObject.SetActive(false);
                    other.gameObject.transform.GetChild(2).gameObject.SetActive(false);
                    other.gameObject.transform.GetChild(3).gameObject.SetActive(true);
                    other.gameObject.transform.GetChild(4).gameObject.SetActive(false);
                    other.gameObject.transform.GetChild(5).transform.GetChild(4).transform.GetChild(0).gameObject.SetActive(false);
                    other.gameObject.transform.GetChild(5).transform.GetChild(4).transform.GetChild(1).gameObject.SetActive(false);
                    other.gameObject.transform.GetChild(5).transform.GetChild(4).transform.GetChild(2).gameObject.SetActive(true);
                    other.gameObject.transform.GetChild(5).transform.GetChild(4).transform.GetChild(3).gameObject.SetActive(false);
                    other.gameObject.transform.GetChild(5).transform.GetChild(4).transform.GetChild(4).gameObject.SetActive(false);
                }
            }
            else
            {
                //afficher canvas deja une classe
            }
        }
    }


}
