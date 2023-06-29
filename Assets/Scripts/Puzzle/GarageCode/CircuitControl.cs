using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitControl : MonoBehaviour
{

    public List<int> correctCode = new List<int> { };
    public List<int> codeEntered = new List<int>();

    public Animator openedBox;
    public AudioSource audioSource;

    private bool codeCompleted = false;

    private void CorrectCodeEntered()
    {
        if (SameLists(codeEntered, correctCode))
        {
            OpenDoor();
        }
        else
        {
            Debug.Log("no");
        }
    }

    private bool SameLists(List<int> list1, List<int> list2)
    {
        if (list1.Count != list2.Count)
        {
            return false;
        }

        for (int i = 0; i < list1.Count; i++)
        {
            if (list1[i] != list2[i])
            {
                return false;
            }
        }

        return true;
    }

    private void OpenDoor()
    {
        audioSource.Play();
        openedBox.SetBool("Open", true);
    }

    public void AddNumber(int keyValue)
    {

        if (codeCompleted)
        {
            return;
        }

        if (correctCode.Contains(keyValue))
        {
            codeEntered.Add(keyValue);

            if (SameLists(codeEntered, correctCode))
            {
                codeCompleted = true;
                CorrectCodeEntered();
            }
        }
        else
        {
            codeEntered.Clear();
        }

    }

    public void ResetCode()
    {
        codeEntered.Clear();
    }

}
