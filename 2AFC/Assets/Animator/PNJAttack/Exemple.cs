using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exemple : MonoBehaviour
{
    private Animator Anim;

    // Update is called once per frame
    void Update()
    {
        int rand = Random.Range(1, 3);
        Anim.SetInteger("Attaque", rand);
    }
}
