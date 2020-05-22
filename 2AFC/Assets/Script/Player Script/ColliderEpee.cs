using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderEpee : MonoBehaviour
{
    public GameObject myPlayer;
    Animator anim;
    Perte_de_vie Vie_Enemie;

    // Start is called before the first frame update
    void Start()
    {
        anim = (Animator)myPlayer.GetComponent<Animator>();
        Vie_Enemie = (Perte_de_vie)FindObjectOfType(typeof(Perte_de_vie));
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "ColliderHead")
        {
            AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(1);
            if(info.IsName("Secondary_attack") || info.IsName("Third_Attack"))
            {
                Vie_Enemie.LooseHealth(12);
            }
        }
        else if(other.gameObject.name == "ColliderBody")
        {
            AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(1);
            if (info.IsName("Secondary_attack") || info.IsName("Third_Attack"))
            {
                Vie_Enemie.LooseHealth(7);
            }
        }
    }
}
