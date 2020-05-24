using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGarde : MonoBehaviour
{
    float speed = 12f;
    private GameObject perso;
    bool proche = false;
    bool attack = false;
    [SerializeField]
    private Animator GardeAnim;
    [SerializeField]
    private VieGARDE GardeVIE;
    /*
    private static ZombieScript instance;

    public static ZombieScript MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ZombieScript>();
            }
            return instance;
        }
    }*/

    void OnTriggerEnter(Collider other)
    {
        perso = other.gameObject;
        proche = true;
    }

    void OnTriggerExit(Collider other)
    {
        proche = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        GardeAnim.SetFloat("Speed", 0);
        GardeAnim.SetInteger("Attack", 0);
    }

    // Update is called once per frame
    //[System.Obsolete]
    void Update()
    {
        //Debug.Log(proche);
        //Debug.Log(distance);


        if (proche)
        {
            float distance;
            Transform target = perso.transform;
            distance = Vector3.Distance(target.position, transform.position);

            attack = true;
            if (distance < 4)
            {
                GardeAnim.SetFloat("Speed", 0);
                TurnTowardTarget(transform, target);
                StartAttack();
            }
            else
            {
                attack = false;
                TurnTowardTarget(transform, target);
                MoveTowardTarget(transform, target);
            }
        }

        //si il a plus de vie
        if (GardeVIE.IsZombieDead())
        {
            Debug.Log("Zombi dead");
            GardeAnim.SetInteger("Attack", 3);
        }
        AnimatorStateInfo info = GardeAnim.GetCurrentAnimatorStateInfo(1);
        if (info.IsName("Dead"))
        {
            Debug.Log("supposed to be destroyed");
            GardeAnim.gameObject.SetActive(false);
        }
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

    private void MoveTowardTarget(Transform source, Transform target)
    {
        float theSpeed = speed * Time.deltaTime;

        source.position = Vector3.MoveTowards(source.position, target.position, theSpeed);

        GardeAnim.SetFloat("Speed", theSpeed);
        GardeAnim.SetInteger("Attack", 0);
    }

    private void StartAttack()
    {
        int attaque;
        attaque = (int)Random.Range(1f, 3f);
        if (attack)
        {
            if (attaque > 2)
                attaque = 2;
            GardeAnim.SetInteger("Attack", attaque);
        }
        else
        {
            GardeAnim.SetInteger("Attack", 0);
        }
    }
}
