using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverControl : MonoBehaviour
{
    private int[] result, correctCombination;
    public Animator CajonLever;
    private AudioSource audioSource;
    private bool isPuzzleCompleted = false;

    private void Start()
    {
        result = new int[] { 1, 1, 1, 1 };
        correctCombination = new int[] { 1, 3, 2, 4 };
        LeverMove.Rotated += CheckResults;
        audioSource = GetComponent<AudioSource>();
    }

    private void CheckResults(string leverName, int number)
    {

        if (isPuzzleCompleted)
        {
            return;
        }

        switch (leverName)
        {
            case "Lever1":
                result[0] = number;
                break;
            case "Lever2":
                result[1] = number;
                break;
            case "Lever3":
                result[2] = number;
                break;
            case "Lever4":
                result[3] = number;
                break;
        }

        if (result[0] == correctCombination[0] && result[1] == correctCombination[1] && result[2] == correctCombination[2] && result[3] == correctCombination[3])
        {
            audioSource.Play();
            CajonLever.SetBool("Open", true);
            isPuzzleCompleted = true;
        }
    }


    private void OnDestroy()
    {
        LeverMove.Rotated -= CheckResults;
    }

    
}