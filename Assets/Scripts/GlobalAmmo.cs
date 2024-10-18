using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalAmmo : MonoBehaviour
{
    public static int AmmoCount;
    public GameObject AmmoDisplay;
    public int InternalAmmo;

    void Update()
    {
        InternalAmmo = AmmoCount;
        AmmoDisplay.GetComponent<Text>().text = "" + AmmoCount;
    }
}
