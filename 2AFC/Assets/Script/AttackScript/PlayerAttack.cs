using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject Player;
    Animator anim;
    Perte_de_vie Vie_Ennemi;


    // Start is called before the first frame update
    void Start()
    {
        anim = (Animator)Player.GetComponent<Animator>();
        Vie_Ennemi = (Perte_de_vie)FindObjectOfType(typeof(Perte_de_vie));
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BoxEnnemi")
        {
            /*Debug.Log(other.gameObject.tag);
            AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(1);

            if (info.IsName(""))
            {*/
                Debug.Log("est en train d'attaquer");
                Vie_Ennemi.LooseHealth(10);
            //}
        }
    }
}
