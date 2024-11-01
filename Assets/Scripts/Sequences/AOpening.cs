using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class AOpening : MonoBehaviour
{
    public GameObject Player;
    public GameObject FadeScreenIn;
    public GameObject TextBox;
    public AudioSource line01;
    public AudioSource line02;

    // Update is called once per frame
    void Start()
    {
        Player.GetComponent<FirstPersonController>().enabled = false;
        StartCoroutine(ScenePlayer());
    }

    IEnumerator ScenePlayer()
    {
        yield return new WaitForSeconds(1.5f);
        FadeScreenIn.SetActive(false);
        TextBox.GetComponent<Text>().text = "Uhh where am I?";
        line01.Play();
        yield return new WaitForSeconds(2);
        TextBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(0.5f);
        TextBox.GetComponent<Text>().text = "I need to get out of here";
        line02.Play();
        yield return new WaitForSeconds(2);
        TextBox.GetComponent<Text>().text = "";
        Player.GetComponent<FirstPersonController>().enabled = true;
    }
}
