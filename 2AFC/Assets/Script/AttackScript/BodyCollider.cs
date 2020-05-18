using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCollider : MonoBehaviour
{
    public GameObject Ennemie;
    Animator _animator;
    PlayerVie Playervie;

    void Start()
    {
        _animator = Ennemie.GetComponent<Animator>();
        Playervie = (PlayerVie)FindObjectOfType(typeof(PlayerVie));
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            AnimatorStateInfo info = _animator.GetCurrentAnimatorStateInfo(1);
            if (info.IsName("Sword1") || info.IsName("Sword2"))
            {
                Debug.Log(other.gameObject.name);
                Playervie.LooseHealth(5);
            }

        }
    }
}
