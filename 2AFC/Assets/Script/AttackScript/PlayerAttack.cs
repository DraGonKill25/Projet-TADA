using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject Player;
       
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BoxEnnemi")
        {
            Perte_de_vie Vie_Ennemie = other.gameObject.GetComponentInParent<Perte_de_vie>();
            Debug.Log("est en train d'attaquer");
            Vie_Ennemie.LooseHealth(50);
        }
    }
}
