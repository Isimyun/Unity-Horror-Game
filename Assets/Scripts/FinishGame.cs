using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{    

    IEnumerator TakeToMenu()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(7);
    }

    void OnTriggerEnter(Collider other)
    {
        StartCoroutine(TakeToMenu());
        PlayerPrefs.SetInt("AutoSave", 0);
    }
}
