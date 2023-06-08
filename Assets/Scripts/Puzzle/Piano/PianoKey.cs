using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoKey : MonoBehaviour
{
    public PianoControl pianoController;
    public string note;
    public int i;

    private void OnMouseDown()
    {
        pianoController.AddNote(note, i);
    }
}
