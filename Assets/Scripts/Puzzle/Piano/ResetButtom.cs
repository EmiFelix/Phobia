using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButtom : MonoBehaviour
{
    private PianoControl pianoController;
    public AudioSource audioSource;
    void Start()
    {
        pianoController = FindObjectOfType<PianoControl>();
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        audioSource.Play();
        pianoController.ResetCode();
    }
}
