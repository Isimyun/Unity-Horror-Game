using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EyePlacement : MonoBehaviour
{
    public float distance;
    public GameObject actionDisplay;
    public GameObject actionText;
    public GameObject extraCross;
    public GameObject eyePieces;
    public GameObject realWall;
    public AudioSource pickUpSound;
    public AudioSource riseSound;

    void Update()
    {
        distance = PlayerCasting.DistanceFromTarget;
    }

    void OnMouseOver()
    {
        if (GlobalInventory.leftEye == true && GlobalInventory.rightEye == true)
        {
            if (distance <= 3)
            {
                actionText.GetComponent<Text>().text = "Place eye pieces";
                extraCross.SetActive(true);
                actionDisplay.SetActive(true);
                actionText.SetActive(true);
            }
            if (Input.GetButtonDown("Action"))
            {
                if (distance <= 3)
                {
                    pickUpSound.Play();
                    GetComponent<BoxCollider>().enabled = false;
                    actionDisplay.SetActive(false);
                    actionText.SetActive(false);
                    extraCross.SetActive(false);
                    eyePieces.SetActive(true);
                    realWall.SetActive(true);
                    realWall.GetComponent<Animator>().Play("RealRise");
                    riseSound.Play();
                }
            }
            if (distance > 3)
            {
                extraCross.SetActive(false);
                actionDisplay.SetActive(false);
                actionText.SetActive(false);
            }
        }
    }

    void OnMouseExit()
    {
        extraCross.SetActive(false);
        actionDisplay.SetActive(false);
        actionText.SetActive(false);
    }
}
