using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LucesKey : MonoBehaviour
{
    public LucesPuzzle lucesPuzzle;
    public string luzValue;
    public AudioSource audioSource;
    public GameObject luz;


    private void Start()
    {
        lucesPuzzle = FindObjectOfType<LucesPuzzle>();
    }

    private void OnMouseDown()
    {
        audioSource.Play();
        luz.SetActive(true);

        if (luzValue == lucesPuzzle.correctCode[lucesPuzzle.codeEntered.Count])
        {
            lucesPuzzle.AddLight(luzValue);
        }
        else
        {
            lucesPuzzle.ResetCode();
        }
    }

}