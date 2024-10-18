using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseDrop : MonoBehaviour
{
    public AudioSource vaseDropSound;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 0.75)
        {
            vaseDropSound.Play();
        }
    }
}
