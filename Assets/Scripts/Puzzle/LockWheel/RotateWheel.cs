using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RotateWheel : MonoBehaviour
{
    public static event Action<string, int> Rotated = delegate { };
    private bool coroutineAllowed;
    private int numberShown;


    void Start()
    {
        coroutineAllowed = true;
        numberShown = 6;
    }

    private void OnMouseDown()
    {
        if (coroutineAllowed)
        {
            StartCoroutine("RotateWheelF");
        }
    }

    private IEnumerator RotateWheelF()
    {
        coroutineAllowed = false;

        for (int i = 0; i <= 11; i++)
        {
            transform.Rotate(0f, -3f, 0f);
            yield return new WaitForSeconds(0.01f);
        }

        

        coroutineAllowed = true;
        numberShown += 1;

        if (numberShown > 9)
        {
            numberShown = 0;
        }

        Rotated(name, numberShown);
    }
}
