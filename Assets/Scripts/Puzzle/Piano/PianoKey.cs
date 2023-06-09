using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoKey : MonoBehaviour
{
    public PianoControl pianoController;
    public string noteValue;
    public AudioSource audioSource;


    private void Start()
    {
        pianoController = FindObjectOfType<PianoControl>();
    }

    private void OnMouseDown()
    {
        audioSource.Play();

        if (noteValue == pianoController.correctCode[pianoController.codeEntered.Count])
        {
        pianoController.AddNote(noteValue);
        }
        else
        {
            pianoController.ResetCode();
        }
    }

}
