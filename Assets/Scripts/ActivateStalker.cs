using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateStalker : MonoBehaviour
{
    public AudioSource monsterScream;
    public GameObject stalker;
    void OnTriggerEnter(Collider other)
    {
        stalker.SetActive(true);
        monsterScream.Play();
        gameObject.GetComponent<Collider>().enabled = false;
        StalkerAI.isStalking = true;
    }
}
