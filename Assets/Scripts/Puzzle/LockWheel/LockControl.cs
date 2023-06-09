using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockControl : MonoBehaviour
{
    private int[] result, correctCombination;
    public Animator TapaCaja;
    private AudioSource audioSource;

    private void Start()
    {
        result = new int[] { 6, 6, 6 };
        correctCombination = new int[] { 3, 9, 7 };
        RotateWheel.Rotated += CheckResults;
        audioSource = GetComponent<AudioSource>();
    }

    private void CheckResults(string wheelName, int number)
    {
        switch (wheelName)
        {
            case "LockWheel1":
                result[0] = number;
                break;
            case "LockWheel2":
                result[1] = number;
                break;
            case "LockWheel3":
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