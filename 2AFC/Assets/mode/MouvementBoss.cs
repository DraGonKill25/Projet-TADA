using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementBoss : MonoBehaviour
{
    public const float DistanceDetection = 10f;
    public const float DistanceContact = 1f;

    public GameObject MyPlayerObject;

    float speed = 0.5f;

    Animator MyAnim;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        MyAnim = GetComponent<Animator>();
        MyAnim.SetFloat("Speed", 0);
        MyAnim.SetInteger("Attack", 0);
    }

    // Update is called once per frame
    void Update()
    {
        float distance;

        Transform target = MyPlayerObject.transform;
        distance = Vector3.Distance(target.position, transform.position);
        if (distance < DistanceDetection)
        {
            if (distance > DistanceContact)
            {
                TurnTowardTarget(transform, target);
                MoveTowardTarget(transform, target);
            }
            else
            {
                StopMoving();
                TurnTowardTarget(transform, target);
                StartAttacking();
            }
        }
        else
        {
            MyAnim.SetFloat("Speed", 0);
        }
    }

    private void StopMoving()
    {
        MyAnim.SetFloat("Speed", 0);
    }
    
    private void TurnTowardTarget(Transform source , Transform target)
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

    private void MoveTowardTarget(Transform source, Transform target)
    {
        float theSpeed = speed * Time.deltaTime;
        source.position = Vector3.MoveTowards(source.position, target.position, theSpeed);
        MyAnim.SetFloat("Speed", theSpeed);
        MyAnim.SetInteger("Attack", 0);
    }

    private void StartAttacking()
    {
        int attack;
        attack = (int)Random.Range(1f, 6f);

        if (attack >= 5)
        {
            MyAnim.SetInteger("Attack", 1);
        }
        else
        {
            if(attack >= 4)
            {
                MyAnim.SetInteger("Attack", 2);
            }
            else
            {
                MyAnim.SetInteger("Attack", 0);
            }
        }
    }
}
