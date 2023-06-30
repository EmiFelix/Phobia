using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButtom : MonoBehaviour
{
    private PianoControl pianoController;
    public AudioSource audioSource;
    private bool canPlaySound = true;
    private bool isPlaying = false;

    void Start()
    {
        pianoController = FindObjectOfType<PianoControl>();
    }

    private void OnMouseDown()
    {

        if (canPlaySound && isPlaying == false)
        {
            audioSource.Play();
            isPlaying = true;
            canPlaySound = false;
            pianoController.ResetCode();
        }
    }

    private void Update()
    {
        if (!isPlaying && !audioSource.isPlaying)
        {
            canPlaySound = true;
        }
    }
}
