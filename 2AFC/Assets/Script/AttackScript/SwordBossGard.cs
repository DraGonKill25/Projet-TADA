using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBossGard : MonoBehaviour
{
    public GameObject Garde;
    Animator anim;
    ViePerso MyPlayerVie;
    


    // Start is called before the first frame update
    void Start()
    {
        anim = (Animator)Garde.GetComponent<Animator>();
        MyPlayerVie = (ViePerso)FindObjectOfType(typeof(ViePerso));
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "boxbody")
        {
            Debug.Log(other.gameObject.tag);
            AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(1);

            if (info.IsName("attack1") || info.IsName("Attack2"))
            {
                Debug.Log("est en train d'attaquer");
                MyPlayerVie.LooseHealth(12);
            }
        }
    }
}
