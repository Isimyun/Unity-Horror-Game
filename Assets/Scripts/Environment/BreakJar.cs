using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakJar : MonoBehaviour
{
    public GameObject normalJar;
    public GameObject brokenJar;
    public GameObject sphere;
    public GameObject keyTrigger;
    public AudioSource jarBreakSound;

    void DamageZombie(int DamageAmount)
    {
        StartCoroutine(JarBroken());
    }

    IEnumerator JarBroken()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        jarBreakSound.Play();
        normalJar.SetActive(false);
        brokenJar.SetActive(true);
        keyTrigger.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        sphere.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        sphere.SetActive(false);
    }
}
