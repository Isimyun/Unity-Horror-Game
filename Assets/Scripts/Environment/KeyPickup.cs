using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPickup : MonoBehaviour
{
    public float distance;
    public GameObject actionDisplay;
    public GameObject actionText;
    public GameObject extraCross;
    public GameObject key;
    public AudioSource keyPickupSound;

    void Update()
    {
        distance = PlayerCasting.DistanceFromTarget;
    }

    void OnMouseOver()
    {
        if (distance <= 3)
        {
            actionText.GetComponent<Text>().text = "Pick up key";
            extraCross.SetActive(true);
            actionDisplay.SetActive(true);
            actionText.SetActive(true);    
        }
        if (Input.GetButtonDown("Action"))
        {
            if (distance <= 3)
            {
                keyPickupSound.Play();
                GetComponent<BoxCollider>().enabled = false;
                actionDisplay.SetActive(false); 
                actionText.SetActive(false);
                extraCross.SetActive(false);
                key.SetActive(false);
                GlobalInventory.firstDoorKey = true;
            }
        }
        if (distance > 3)
        {
            extraCross.SetActive(false);
            actionDisplay.SetActive(false);
            actionText.SetActive(false);
        }
    }

    void OnMouseExit()
    {
        extraCross.SetActive(false);
        actionDisplay.SetActive(false);
        actionText.SetActive(false);
    }
}
