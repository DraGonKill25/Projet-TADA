using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    float speed = 4f;
    private GameObject perso;
    bool proche = false;
    bool attack = false;
    [SerializeField]
    private Animator ZombieAnim;
    [SerializeField]
    private Perte_de_vie ZombieVie;
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
        ZombieAnim.SetFloat("Speed", 0);
        ZombieAnim.SetInteger("Attack", 0);
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
                ZombieAnim.SetFloat("Speed", 0);
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
        if (ZombieVie.IsZombieDead()){
            Debug.Log("Zombi dead");
            ZombieAnim.SetInteger("Attack", 2);
        }
        AnimatorStateInfo info = ZombieAnim.GetCurrentAnimatorStateInfo(1);
        if (info.IsName("Dead")){
            Debug.Log("supposed to be destroyed");
            ZombieAnim.gameObject.SetActive(false);
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

        ZombieAnim.SetFloat("Speed", theSpeed);
        ZombieAnim.SetInteger("Attack", 0);
    }

    private void StartAttack()
    {
        int attaque;
        attaque = (int)Random.Range(1f, 3f);
        if (attack)
        {
            ZombieAnim.SetInteger("Attack", 1);
        }
        else
        {
            ZombieAnim.SetInteger("Attack", 0);
        }
    }
}
