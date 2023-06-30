using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class BoxWheel : MonoBehaviour
{
    public static event Action<string, int> RotatedBox = delegate { };
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
            StartCoroutine("BoxWheelF");
        }
    }

    private IEnumerator BoxWheelF()
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

        RotatedBox(name, numberShown);
    }
}
