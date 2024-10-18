using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;

public class DoorOpen : MonoBehaviour
{
    public float Distance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject Door;
    public AudioSource CreakSound;
    public GameObject ExtraCross;

    // Update is called once per frame
    void Update()
    {
        Distance = PlayerCasting.DistanceFromTarget;
    }

    void OnMouseOver()
    {
        if (Distance <= 2)
        {
            ActionText.GetComponent<Text>().text = "Open the door";
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
            ExtraCross.SetActive(true);
        }
        if (Input.GetButtonDown("Action"))
        {
            if (Distance <= 2)
            {
                GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive(false); 
                ActionText.SetActive(false);
                Door.GetComponent<Animation>().Play("FirstDoorOpenAnim");
                CreakSound.Play();
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
}
