using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mereIA : MonoBehaviour
{
    public const float DistanceDectec = 10f;
    public const float DistanceContact = 2f;

    public GameObject MyPlayerObject;

    Animator AnimBossMere;

    // Start is called before the first frame update
    void Start()
    {
        AnimBossMere = (Animator)GetComponent<Animator>();
        if(AnimBossMere == null)
        {
            Debug.LogError("Erreur pour trouver l'animation");
        }
    }

    // Update is called once per frame
    void Update()
    {
        float distance;
        Transform Target = MyPlayerObject.transform;

        distance = Vector3.Distance(Target.position, transform.position);

        if(distance < DistanceContact)
        {
            Debug.Log("Cible au contact (" + distance + ")");
            StopMouvement(AnimBossMere);
        }
        else
        {
            if (distance < DistanceDectec)
            {
                Debug.Log("Cible detectee (" + distance + ")");
                //se tourner vers la cible
                TurnTowardTarget(transform, Target);

                //se deplacer vers la cible
                MoveTowardTarget(AnimBossMere);
            }
            else
            {
                Debug.Log("Cible perdu (" + distance + ")");
                StopMouvement(AnimBossMere);
                
            }
        }
    }

    private void StopMouvement(Animator anim)
    {
        anim.SetInteger("Marche", 0);
    }

    private void MoveTowardTarget(Animator anim)
    {
        anim.SetInteger("Marche", 1);
    }

    private void TurnTowardTarget(Transform source, Transform target)
    {
        Quaternion quat;

        quat = Quaternion.LookRotation(target.position - source.position);

        Vector3 vv;
        vv = quat.eulerAngles;
        vv.x = 0;
        vv.z = 0;
        quat = Quaternion.Euler(vv);

        source.rotation = quat;
    }
}
