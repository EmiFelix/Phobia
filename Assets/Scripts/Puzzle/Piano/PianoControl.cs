using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoControl : MonoBehaviour
{
    private int[] result, correctCombination;
    public Animator TapaCaja;
    private AudioSource audioSource;

    private void Start()
    {
        result = new int[] { 0, 0, 0 };
        correctCombination = new int[] { 1, 2, 3 };
        RotateWheel.Rotated += CheckResults;
        audioSource = GetComponent<AudioSource>();
    }

    private void CheckResults(string keyName, int number)
    {
        switch (keyName)
        {
            case "TeclaB1":
                result[0] = number;
                break;
            case "TeclaB2":
                result[1] = number;
                break;
            case "TeclaB3":
                result[2] = number;
                break;
        }

        if (result[0] == correctCombination[0] && result[1] == correctCombination[1] && result[2] == correctCombination[2])
        {
            Debug.Log("Opened hehe");
            audioSource.Play();
            TapaCaja.SetBool("Open", true);
        }
    }

    private void OnDestroy()
    {
        RotateWheel.Rotated -= CheckResults;
    }
}
