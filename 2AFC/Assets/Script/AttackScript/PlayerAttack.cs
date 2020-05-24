﻿using System.Collections;
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
            Vie_Ennemie.LooseHealth(50);
        }

        if(other.gameObject.tag == "garde")
        {
            VieGARDE Vie_Ennemie = other.gameObject.GetComponentInParent<VieGARDE>();
            Vie_Ennemie.LooseHealth(50);
        }
    }
}
