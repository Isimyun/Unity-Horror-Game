using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightEyePickup1 : MonoBehaviour
{
    public float distance;
    public GameObject actionDisplay;
    public GameObject actionText;
    public GameObject extraCross;
    public GameObject rightEye;
    public GameObject rightEyeImage;
    public GameObject halfFade;
    public GameObject textBox;
    public GameObject fakeWall;
    public GameObject realWall;
    public AudioSource pickUpSound;

    void Update()
    {
        distance = PlayerCasting.DistanceFromTarget;
    }

    void OnMouseOver()
    {
        if (distance <= 3)
        {
            actionText.GetComponent<Text>().text = "Pick up right eye";
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
                GlobalInventory.rightEye = true;
                StartCoroutine(PickedUpRightEye());
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

    IEnumerator PickedUpRightEye()
    {
        fakeWall.SetActive(false);
        realWall.SetActive(true);
        textBox.GetComponent<Text>().text = "Picked up right eye";
        rightEyeImage.SetActive(true);
        halfFade.SetActive(true);
        textBox.SetActive(true);
        yield return new WaitForSeconds(2);
        textBox.GetComponent<Text>().text = "";
        halfFade.SetActive(false);
        textBox.SetActive(false);
        rightEye.SetActive(false);
        rightEyeImage.SetActive(false);
    }
}
