using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxControl : MonoBehaviour
{
    private int[] result, correctCombination;
    public Animator TapaCaja2;
    private AudioSource audioSource;

    private bool isPuzzleCompleted = false;

    private void Start()
    {
        result = new int[] { 6, 6, 6 };
        correctCombination = new int[] { 8, 0, 3 };
        BoxWheel.RotatedBox += CheckResults;
        audioSource = GetComponent<AudioSource>();
    }

    private void CheckResults(string wheelBoxName, int number)
    {

        if (isPuzzleCompleted) return;

        switch (wheelBoxName)
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
            audioSource.Play();
            TapaCaja2.SetBool("Open", true);
            isPuzzleCompleted = true;
        }
    }

    private void OnDestroy()
    {
        BoxWheel.RotatedBox -= CheckResults;
    }
}
