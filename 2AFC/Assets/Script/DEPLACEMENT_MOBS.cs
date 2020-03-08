using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DEPLACEMENT_MOBS : MonoBehaviour
{

    private RaycastHit Hit;

    private NavMeshAgent mob;

    public GameObject player;

    public float mobDistanceRun = 4.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        mob = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance < mobDistanceRun)
        {
            Vector3 dirToPlayer = transform.position - player.transform.position;

            Vector3 newPos = transform.position - dirToPlayer;

            mob.SetDestination(newPos);
        }
        else
        {
            transform.Translate(Vector3.forward * 5 * Time.deltaTime);
            
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit, 3))
            {
                transform.Rotate(Vector3.up * Random.Range(145, 230));
            }
        }

        

        


    }
}
