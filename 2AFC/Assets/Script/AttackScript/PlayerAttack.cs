using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject Player;
       
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BoxEnnemi" || other.gameObject.tag == "garde")
        {
            Perte_de_vie Vie_Ennemie = other.gameObject.GetComponentInParent<Perte_de_vie>();
            VieGARDE Vie_Garde = other.gameObject.GetComponentInParent<VieGARDE>();
            if(Vie_Ennemie != null)
                Vie_Ennemie.LooseHealth(50);

            if (Vie_Garde != null)
                Vie_Garde.LooseHealth(50);
        }
    }
}
