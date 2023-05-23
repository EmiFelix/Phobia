using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockControl : MonoBehaviour
{
    private int[] result, correctCombination;
    //private Animator Cajon;

    private void Start()
    {
        result = new int[] { 9, 9, 9 };
        correctCombination = new int[] { 3, 7, 9 };
        RotateWheel.Rotated += CheckResults;
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
            //Cajon.SetBool("Open", true);
        }
    }

    private void OnDestroy()
    {
        RotateWheel.Rotated -= CheckResults;
    }
}