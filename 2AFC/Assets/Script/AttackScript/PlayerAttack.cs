using Script;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject Player;
    public PlayerStats stat;
       
    public void OnTriggerEnter(Collider other)
    {
        int damage = (int)(stat.item.Damage * 0.01) + (int)stat.Attributes[1].amount;

        if (other.gameObject.tag == "BoxEnnemi")
        {
            Perte_de_vie Vie_Ennemie = other.gameObject.GetComponentInParent<Perte_de_vie>();
            Vie_Ennemie.LooseHealth(damage);
        }

        if(other.gameObject.tag == "garde")
        {
            VieGARDE Vie_Garde = other.gameObject.GetComponentInParent<VieGARDE>();
            Vie_Garde.LooseHealth(damage);  
        }
    }
}
