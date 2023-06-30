using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitKey : MonoBehaviour
{
    public CircuitControl circuitControl;
    public int keyValue;
    public AudioSource audioSource;
    public GameObject luz;


    private void Start()
    {
         circuitControl = FindObjectOfType<CircuitControl>();
    }

    private void OnMouseDown()
    {
        audioSource.Play();
        luz.SetActive(true);

        if (keyValue == circuitControl.correctCode[circuitControl.codeEntered.Count])
        {
            circuitControl.AddNumber(keyValue);
        }
        else
        {
            circuitControl.ResetCode();
        }
    }

}