using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mereIA : MonoBehaviour
{
    public const float DistanceDectec = 10f;
    public const float DistanceContact = 2f;
    float speed = 0.5f;

    public GameObject MyPlayerObject;

    Animator AnimBossMere;

    // Start is called before the first frame update
    void Start()
    {
        AnimBossMere = GetComponent<Animator>();
        AnimBossMere.SetFloat("Speed", 0);
        AnimBossMere.SetInteger("Attack", 0);
    }

    // Update is called once per frame
    void Update()
    {
        float distance;
        Transform Target = MyPlayerObject.transform;

        distance = Vector3.Distance(Target.position, transform.position);
        
        if(distance <= DistanceDectec)
        {
            if (distance > DistanceContact)
            {
                TurnTowardTarget(transform, Target);
                MoveTowardTarget(transform, Target);
            }
            else
            {
                StopMovement();
                TurnTowardTarget(transform, Target);
                StartAttacking();
            }
        }
        else
        {
            StopMovement();
        }
    }

    private void MoveTowardTarget(Transform source, Transform target)
    {
        //anim.SetInteger("Speed", 0);
        float theSpeed = speed * Time.deltaTime;
        source.position = Vector3.MoveTowards(source.position, target.position, theSpeed);
        AnimBossMere.SetFloat("Speed", theSpeed);
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
        int attack = (int)Random.Range(1f, 6f);

        if(attack >= 5)
        {
            AnimBossMere.SetInteger("Attack", 1);
        }
        else
        {
            if(attack >= 4)
            {
                AnimBossMere.SetInteger("Attack", 2);
            }
            else
            {
                AnimBossMere.SetInteger("Attack", 0);
            }
        }
    }
}
