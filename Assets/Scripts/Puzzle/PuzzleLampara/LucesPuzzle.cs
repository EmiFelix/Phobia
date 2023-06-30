using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LucesPuzzle : MonoBehaviour
{

    public List<string> correctCode = new List<string> { };
    public List<string> codeEntered = new List<string>();

    public Animator openedBox;
    public AudioSource audioSource;
    public GameObject luz;

    private bool codeCompleted = false;
    private bool isLightOn = false;

    private void CorrectCodeEntered()
    {
        if (SameLists(codeEntered, correctCode))
        {

            OpenDoor();
            KeepLightOn();
        }
        else
        {
            Debug.Log("no");
            TurnOffLight();
        }
    }

    private bool SameLists(List<string> list1, List<string> list2)
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

    private void KeepLightOn()
    {
        if (!isLightOn)
        {
            isLightOn = true;
            InvokeRepeating("TurnOffLiht", 3f, 3f);
        }
    }

    private void TurnOffLight()
    {
        isLightOn = false;
        luz.SetActive(false);
    }

    public void AddLight(string luzValue)
    {

        if (codeCompleted)
        {
            return;
        }

        if (correctCode.Contains(luzValue))
        {
            codeEntered.Add(luzValue);

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
