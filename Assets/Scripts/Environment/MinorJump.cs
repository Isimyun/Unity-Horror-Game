using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinorJump : MonoBehaviour
{
    public GameObject flyingObject;
    public GameObject flingObject;
    public AudioSource objectJumpScareSound;

    private void OnTriggerEnter()
    {
        GetComponent<Collider>().enabled = false;
        flingObject.SetActive(true);
        objectJumpScareSound.Play();
        StartCoroutine(deactivateSphere());
    }

    IEnumerator deactivateSphere()
    {
        yield return new WaitForSeconds(0.5f);
        flingObject.SetActive(false);
    }
}
