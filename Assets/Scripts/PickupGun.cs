using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;

public class PickUpGun : MonoBehaviour
{
    public float Distance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject GunOnTable;
    public GameObject GunOnHand;
    public GameObject GuideArrow;
    public GameObject ExtraCross;
    public GameObject JumpTrigger;

    void Update()
    {
        Distance = PlayerCasting.DistanceFromTarget;
    }

    void OnMouseOver()
    {
        if (Distance <= 3)
        {
            ActionText.GetComponent<Text>().text = "Pick up gun";
            ExtraCross.SetActive(true);
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);    
        }
        if (Input.GetButtonDown("Action"))
        {
            if (Distance <= 3)
            {
                GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive(false); 
                ActionText.SetActive(false);
                GunOnTable.SetActive(false);
                GunOnHand.SetActive(true);
                ExtraCross.SetActive(false);
                GuideArrow.SetActive(false);
                JumpTrigger.SetActive(true);
            }
        }
        if (Distance > 3)
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
