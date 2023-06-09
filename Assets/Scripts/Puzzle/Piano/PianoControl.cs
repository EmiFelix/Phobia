using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PianoControl : MonoBehaviour
{
    public List<string> correctCode = new List<string>{};
    public List<string> codeEntered = new List<string>();

    private bool codeCompleted = false;

    public Animator openedDrawer;
    public AudioSource audioSource;

    private void CorrectCodeEntered()
    {
        if(SameLists(codeEntered, correctCode))
        {         
            OpenDoor(); 
        }
        else
        {
            Debug.Log("no");
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
        openedDrawer.SetBool("Open", true);
    }

    public void AddNote(string noteValue)
    {

        if (codeCompleted)
        {
            return;
        }

        if (correctCode.Contains(noteValue))
        {
            Debug.Log("nota correcta");
        codeEntered.Add(noteValue);
        CorrectCodeEntered();
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
