using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalHealth : MonoBehaviour
{
    public static int CurrentHealth = 20;
    public static int InternalHealth;


    void Update()
    {
        InternalHealth = CurrentHealth;

        if(CurrentHealth <= 0)
        {
            SceneManager.LoadScene(3);
        }
    }
}
