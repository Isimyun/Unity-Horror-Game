using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFunction : MonoBehaviour
{
    public GameObject fadeOut;
    public GameObject loadText;
    public GameObject loadButton;
    public int loadInt;
    public AudioSource buttonClick;

    void Start()
    {
        loadInt = PlayerPrefs.GetInt("AutoSave");

        if (loadInt > 0)
        {
            loadButton.SetActive(true);
        }
    }

    public void NewGameButton()
    {
        StartCoroutine(NewGameStart());
    }

    IEnumerator NewGameStart()
    {
        loadInt = 0;
        fadeOut.SetActive(true);
        buttonClick.Play();
        yield return new WaitForSeconds(3);
        loadText.SetActive(true);
        SceneManager.LoadScene(4);
    }

    public void LoadGameButton()
    {
        StartCoroutine(LoadGameStart());
    }

    IEnumerator LoadGameStart()
    {
        fadeOut.SetActive(true);
        buttonClick.Play();
        yield return new WaitForSeconds(3);
        loadText.SetActive(true);
        SceneManager.LoadScene(loadInt);
    }

    public void CreditButton()
    {
        StartCoroutine(CreditStart());
    }

    IEnumerator CreditStart()
    {
        fadeOut.SetActive(true);
        buttonClick.Play();
        yield return new WaitForSeconds(3);
        loadText.SetActive(true);
        SceneManager.LoadScene(6);
    }
}
