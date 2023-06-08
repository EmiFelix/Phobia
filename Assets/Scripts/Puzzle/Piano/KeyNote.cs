using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyNote : MonoBehaviour
{
    public AudioSource audioSource;

    
    private void OnMouseDown()
    {
        audioSource.Play();
    }

    private void OnMouseUp()
    {
        audioSource.Stop();
    }
}
