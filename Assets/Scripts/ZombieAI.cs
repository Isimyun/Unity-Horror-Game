using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAI : MonoBehaviour
{
    public GameObject Player;
    public GameObject Zombie;
    public GameObject Flash;
    public float ZombieSpeed = 0.01f;
    public bool AttackTrigger = false;
    public bool IsAttacking = false;
    public AudioSource HurtSound1;
    public AudioSource HurtSound2;
    public AudioSource HurtSound3;
    public int HurtGen;

    void Update()
    {
        transform.LookAt(Player.transform);

        if (AttackTrigger == false)
        {
            ZombieSpeed = 0.01f;
            Zombie.GetComponent<Animation>().Play("Z_Walk_InPlace 1");
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, ZombieSpeed);
        }

        if(AttackTrigger == true && IsAttacking == false)
        {
            ZombieSpeed = 0;
            Zombie.GetComponent<Animation>().Play("Z_Attack 2");
            StartCoroutine(InflictDamage());
        }
    }

    void OnTriggerEnter()
    {
        AttackTrigger = true;
    }

    void OnTriggerExit()
    {
        AttackTrigger = false;
    }


    IEnumerator InflictDamage() 
    { 
        IsAttacking = true;

        if (HurtGen == 1)
        {
            HurtSound1.Play();
        }
        if (HurtGen == 2)
        {
            HurtSound2.Play();
        }
        if (HurtGen == 3)
        {
            HurtSound3.Play();
        }

        Flash.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        Flash.SetActive(false);
        GlobalHealth.CurrentHealth -= 5;
        HurtGen = Random.Range(1, 4);
        yield return new WaitForSeconds(0.9f);
        IsAttacking = false;
    }
}
