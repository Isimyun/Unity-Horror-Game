using System.Collections;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class BFirstTrigger : MonoBehaviour
{
    public GameObject Player;
    public GameObject TextBox;
    public GameObject Marker;
    public GameObject AmmoMarker;
    public GameObject Trigger;
    public AudioSource line03;

    void OnTriggerEnter()
    {
        GetComponent<BoxCollider>().enabled = false;
        Player.GetComponent<FirstPersonController>().enabled = false;
        StartCoroutine(ScenePlayer());

    }

    IEnumerator ScenePlayer()
    {
        TextBox.GetComponent<Text>().text = "Looks like there's a weapon on the table";
        line03.Play();
        yield return new WaitForSeconds(2.5f);
        TextBox.GetComponent<Text>().text = "";
        Player.GetComponent<FirstPersonController>().enabled = true;
        Marker.SetActive(true);
        AmmoMarker.SetActive(true);
        yield return new WaitForSeconds(1f);
        Trigger.GetComponent<BoxCollider>().enabled = false;
    }
}
