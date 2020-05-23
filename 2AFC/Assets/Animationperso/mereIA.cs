using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class mereIA : MonoBehaviour
{
    private const float DistanceDectec = 15f;
    private const float DistanceContact = 2f;
    private float speed = 0.7f;
    private bool follow = false;
    private Collider perso;
    //public GameObject MyPlayerObject;
    Animator AnimBossMere;



    void OnTriggerEnter(Collider other)
    {
        perso = other;
        follow = true;
    }

    void OnTriggerExit(Collider other)
    {
        perso = null;
        follow = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        AnimBossMere = GetComponent<Animator>();
        AnimBossMere.SetInteger("Speed", 0);
        AnimBossMere.SetInteger("Attack", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (follow)
        {
            float distante = Vector3.Distance(perso.gameObject.transform.position, transform.position);

            if (distante <= DistanceDectec)
            {
                if (distante > DistanceContact)
                {
                    TurnTowardTarget(transform, perso.gameObject.transform);
                    MoveTowardTarget(transform, perso.gameObject.transform);
                    AnimBossMere.SetInteger("Speed", 1);
                }
                else
                {
                    StopMovement();
                    TurnTowardTarget(transform, perso.gameObject.transform);
                    StartAttacking();
                }
            }
            else
            {
                StopMovement();
                AnimBossMere.SetInteger("Speed", 0);
            }
        }
    }

    private void MoveTowardTarget(Transform source, Transform target)
    {
        float theSpeed = speed * Time.deltaTime;
        source.position = Vector3.MoveTowards(source.position, target.position, theSpeed);
        AnimBossMere.SetInteger("Speed", 1);
        AnimBossMere.SetInteger("Attack", 0);
    }

    private void StopMovement()
    {
        AnimBossMere.SetInteger("Speed", 0);
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

    private void StartAttacking()
    {
        int attack = (int)Random.Range(1f, 9f);

        if(attack >= 5)
        {
            AnimBossMere.SetInteger("Attack", 1);
        }
        else
        {
            AnimBossMere.SetInteger("Attack", 2);
        }
    }
}
