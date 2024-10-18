using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StalkerAI : MonoBehaviour
{
    public GameObject stalkerDestination;
    public GameObject stalkerEnemy;
    public static bool isStalking;
    NavMeshAgent stalkerAgent;
    public bool AttackTrigger = false;
    public bool IsAttacking = false;
    public AudioSource HurtSound1;
    public AudioSource HurtSound2;
    public AudioSource HurtSound3;
    public int HurtGen;
    public GameObject Flash;

    // Start is called before the first frame update
    void Start()
    {
        stalkerAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isStalking == false)
        {
            stalkerEnemy.GetComponent<Animator>().Play("Idle");
        }
        else
        {
            //if (AttackTrigger == true && IsAttacking == false)
            //{
            //    stalkerEnemy.GetComponent<Animation>().Play("Attack");
            //    StartCoroutine(InflictDamage());
            //}
            stalkerEnemy.GetComponent<Animator>().Play("Walking");
            stalkerAgent.SetDestination(stalkerDestination.transform.position);
            //StartCoroutine(InflictDamage());
        }
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        AttackTrigger = true;
    //    }
    //}

    //void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        AttackTrigger = false;
    //    }
    //}


    //IEnumerator InflictDamage()
    //{
    //    IsAttacking = true;

    //    if (HurtGen == 1)
    //    {
    //        HurtSound1.Play();
    //    }
    //    if (HurtGen == 2)
    //    {
    //        HurtSound2.Play();
    //    }
    //    if (HurtGen == 3)
    //    {
    //        HurtSound3.Play();
    //    }

    //    Flash.SetActive(true);
    //    yield return new WaitForSeconds(0.3f);
    //    Flash.SetActive(false);
    //    GlobalHealth.CurrentHealth -= 5;
    //    HurtGen = Random.Range(1, 4);
    //    yield return new WaitForSeconds(0.9f);
    //    IsAttacking = false;
    //}
}
