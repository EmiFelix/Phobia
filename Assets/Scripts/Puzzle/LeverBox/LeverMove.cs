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

    private float[] leverPositions;
    Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
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
        else if (numberShown >= leverPositions.Length)
        {
            ResetLever();

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

    private void ResetLever()
    {
        numberShown = 1;
        transform.position = initialPosition;
    }
}

  






