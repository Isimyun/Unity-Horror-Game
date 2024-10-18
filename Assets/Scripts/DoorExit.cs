using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class DoorExit : MonoBehaviour
{
    public float Distance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject FadeOut;
    public GameObject ExtraCross;
    public GameObject Player;
    public GameObject loadingText;
    public AudioSource openDoorSound;

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
                openDoorSound.Play();
                GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive(false); 
                ActionText.SetActive(false);
                FadeOut.SetActive(true);
                Player.GetComponent<FirstPersonController>().enabled = false;
                StartCoroutine(FadeToExit());
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

    IEnumerator FadeToExit()
    {
        yield return new WaitForSeconds(1);
        loadingText.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(5);
    }
}
