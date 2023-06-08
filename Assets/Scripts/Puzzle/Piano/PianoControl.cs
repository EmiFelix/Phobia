using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoControl : MonoBehaviour
{
    public string[] correctCode = { "Do", "Re", "Mi", "Fa" };
    private string[] codeEntered = new string[4];

    public Animator openedDrawer;
    public AudioSource audioSource;

    private void CorrectCodeEntered()
    {
        bool isCorrectCode = true;

        for (int i = 0; i < codeEntered.Length; i++)
        {
            if (codeEntered[i] != correctCode[i])
            {
                Debug.Log("no no no");
                isCorrectCode = false;
                break;
            }            
        }

        if (isCorrectCode)
        {
            OpenDoor();
        Debug.Log("ahoda zi");
        } else
        {
            Debug.Log("No de nuevo decia");
        }
    }

    private void OpenDoor()
    {
        Debug.Log("Opened hehe");
        audioSource.Play();
        openedDrawer.SetBool("Open", true);
    }

    public void AddNote(string note, int i)
    {
        codeEntered[i] = note;

        CorrectCodeEntered();
    }

}
