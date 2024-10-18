using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockedDoor : MonoBehaviour
{
    public float Distance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject ExtraCross;
    public GameObject firstKeyDoor;
    public AudioSource LockedDoorSound;
    public AudioSource doorOpen;

    void Update()
    {
        Distance = PlayerCasting.DistanceFromTarget;
    }

    void OnMouseOver()
    {
        if (Distance <= 2)
        {
            if (GlobalInventory.firstDoorKey == false)
            {
                ActionText.GetComponent<Text>().text = "(Locked) Find the key";
            }
            if (GlobalInventory.firstDoorKey == true)
            {
                ActionText.GetComponent<Text>().text = "Open the door";
            }
            ExtraCross.SetActive(true);
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
        }
        if (Input.GetButtonDown("Action"))
        {
            if (Distance <= 2)
            {
                GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive(false); 
                ActionText.SetActive(false);
                ExtraCross.SetActive(false);
                StartCoroutine(DoorReset());
            }
        }
        if (Distance > 2)
        {
            ExtraCross.SetActive(false);
            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);
        }
    }

    void OnMouseExit()
    {
        ExtraCross.SetActive(false);
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }

    IEnumerator DoorReset()
    {
        if (GlobalInventory.firstDoorKey == false)
        {
            LockedDoorSound.Play();
            yield return new WaitForSeconds(1);
            GetComponent<BoxCollider>().enabled = true;
        }
        else
        {
            firstKeyDoor.GetComponent<Animator>().Play("FirstKeyDoorAnim");
            doorOpen.Play();
            yield return new WaitForSeconds(1);
            GetComponent<BoxCollider>().enabled = false;
        }
        
    }
}
