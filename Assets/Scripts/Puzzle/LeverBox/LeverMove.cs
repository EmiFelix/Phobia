using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeverMove : MonoBehaviour
{
    public static event Action<string, int> Rotated = delegate { };
    private bool coroutineAllowed;
    private int numberShown;
    public float moveSpeed = 1f;
    public float moveDuration = 1f;
    public float moveDistance = 1f;

    void Start()
    {
        coroutineAllowed = true;
        numberShown = 1;
    }

    private void OnMouseDown()
    {
        if (coroutineAllowed)
        {
            StartCoroutine("MoveLeverCoroutine");
        }
    }

    private IEnumerator MoveLeverCoroutine()
    {
        coroutineAllowed = false;

        if (numberShown != 4)
        {
            yield return StartCoroutine(MoveLeverDown());
            numberShown++;
        }
        else if(numberShown != 1) 
        {
            yield return StartCoroutine(MoveLeverUp());
            numberShown--;
        }

        coroutineAllowed = true;

        Rotated(name, numberShown);
    }

    private IEnumerator MoveLeverDown()
    {
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = new Vector3(startPosition.x, startPosition.y - moveDistance, startPosition.z);
        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            float t = elapsedTime / moveDuration;
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
    }

    private IEnumerator MoveLeverUp()
    {
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = new Vector3(startPosition.x, startPosition.y + moveDistance, startPosition.z);
        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            float t = elapsedTime / moveDuration;
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
    }
}

    //private IEnumerator LeverMoveF()
    //{

    //    coroutineAllowed = false;

    //    for (int i = 0; i <= 5; i++)
    //    {
    //        transform.TransformVector(0f, -3f, 0f);
    //        yield return new WaitForSeconds(0.01f);
    //    }



    //    coroutineAllowed = true;
    //    numberShown += 1;

    //    if (numberShown > 4)
    //    {
    //        numberShown = 1;
    //    }

    //    Rotated(name, numberShown);
    //}







