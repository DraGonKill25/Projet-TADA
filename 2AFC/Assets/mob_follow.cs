using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class mob_follow : MonoBehaviour
{
    // Start is called before the first frame update

    public NavMeshAgent mob;
    
    public float mobDistanceRun = 4.0f;
    
    void Start()
    {
        mob = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
       

        float distance = Vector3.Distance(mob.transform.position,transform.position);

        if (distance < mobDistanceRun)
        {
            Vector3 dirToPlayer = mob.transform.position -transform.position;

            Vector3 newPos = dirToPlayer - mob.transform.position ;

            mob.SetDestination(newPos);
        }
}
}
