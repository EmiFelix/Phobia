using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PianoControl : MonoBehaviour
{
    public List<string> correctCode = new List<string>{};
    public List<string> codeEntered = new List<string>();

    //public PianoKey button1;
    //public PianoKey button2;
    //public PianoKey button3;
    //public PianoKey button4;

    public Animator openedDrawer;
    public AudioSource audioSource;

    private void CorrectCodeEntered()
    {
        if(SameLists(codeEntered, correctCode))
        {
            Debug.Log("ahoda zi");
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
        Debug.Log("Opened hehe");
        audioSource.Play();
        openedDrawer.SetBool("Open", true);
    }

    public void AddNote(string noteValue)
    {
        if (correctCode.Contains(noteValue))
        {
            Debug.Log("nota correcta");
        codeEntered.Add(noteValue);
        CorrectCodeEntered();
        }
        else
        {
            Debug.Log("Reset codigo");
            codeEntered.Clear();
        }

    }

    public void ResetCode()
    {
        codeEntered.Clear();
    }

}
