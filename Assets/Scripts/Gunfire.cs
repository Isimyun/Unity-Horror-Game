using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunfire : MonoBehaviour
{
    public GameObject Gun;
    public GameObject MuzzleFlash;
    public AudioSource GunFire;
    public bool IsFiring = false;
    public float TargetDistance;
    public int DamageAmount = 5;

    void Update()
    {
        if(Input.GetButtonDown("Fire1") && GlobalAmmo.AmmoCount >= 1)
        {
            if (IsFiring == false)
            {
                GlobalAmmo.AmmoCount -= 1;
                StartCoroutine(FiringGun());
            }
        }
    }

    IEnumerator FiringGun()
    {
        IsFiring = true;
        RaycastHit Shot;

        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
        {
            TargetDistance = Shot.distance;
            Shot.transform.SendMessage("DamageZombie", DamageAmount, SendMessageOptions.DontRequireReceiver);
        }

        Gun.GetComponent<Animation>().Play("GunShotAnim");
        MuzzleFlash.SetActive(true);
        MuzzleFlash.GetComponent<Animation>().Play("MuzzleAnim");
        GunFire.Play();
        yield return new WaitForSeconds(0.5f);
        IsFiring = false;
    }
}
