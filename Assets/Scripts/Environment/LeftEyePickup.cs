using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftEyePickup : MonoBehaviour
{
    public float distance;
    public GameObject actionDisplay;
    public GameObject actionText;
    public GameObject extraCross;
    public GameObject leftEye;
    public GameObject leftEyeImage;
    public GameObject halfFade;
    public GameObject textBox;
    public AudioSource pickUpSound;

    void Update()
    {
        distance = PlayerCasting.DistanceFromTarget;
    }

    void OnMouseOver()
    {
        if (distance <= 3)
        {
            actionText.GetComponent<Text>().text = "Pick up left eye";
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
                GlobalInventory.leftEye = true;
                StartCoroutine(PickedUpLeftEye());
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

    IEnumerator PickedUpLeftEye()
    {
        leftEyeImage.SetActive(true);
        halfFade.SetActive(true);
        textBox.SetActive(true);
        textBox.GetComponent<Text>().text = "Picked up left eye";
        yield return new WaitForSeconds(2);
        textBox.GetComponent<Text>().text = "";
        halfFade.SetActive(false);
        textBox.SetActive(false);
        leftEye.SetActive(false);
        leftEyeImage.SetActive(false);
    }
}
