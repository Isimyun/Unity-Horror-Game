using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalInventory : MonoBehaviour
{
    public static bool firstDoorKey = false;
    public static bool leftEye = false;
    public static bool rightEye = false;
    public bool internalDoorKey = false;

    private void Update()
    {
        internalDoorKey = firstDoorKey;
    }
}
