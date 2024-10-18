using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDeath : MonoBehaviour
{
    public int ZombieHealth = 20;
    public GameObject Zombie;
    public int StatusCheck;
    public AudioSource JumpScareSound;
    public AudioSource AmbMusic;

    void DamageZombie(int DamageAmount)
    {
        ZombieHealth -= DamageAmount;
    }

    // Update is called once per frame
    void Update()
    {
        if(ZombieHealth <= 0 && StatusCheck == 0)
        {
            GetComponent<ZombieAI>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            StatusCheck = 2;
            Zombie.GetComponent<Animation>().Stop("Z_Walk 3");
            Zombie.GetComponent<Animation>().Play("Z_FallingBack 1");
            JumpScareSound.Stop();
            AmbMusic.Play();
        }
    }
}
