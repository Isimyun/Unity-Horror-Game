using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public GameObject Ammobox;
    public GameObject AmmoDisplayBox;
    public GameObject GuideArrow2;

    void OnTriggerEnter()
    {
        Ammobox.SetActive(false);
        GlobalAmmo.AmmoCount += 7;
        AmmoDisplayBox.SetActive(true);
        GuideArrow2.SetActive(false);
    }
}
