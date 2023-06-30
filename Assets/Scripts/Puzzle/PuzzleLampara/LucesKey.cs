using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LucesKey : MonoBehaviour
{
    public LucesPuzzle lucesPuzzle;
    public string luzValue;
    public AudioSource audioSource;
    public GameObject luz;
    public float duration = 1f;


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


            if (lucesPuzzle.codeEntered.Count == lucesPuzzle.correctCode.Count)
            {
                
            }
            else
            {
                StartCoroutine(TurnOffLights());
            }
        }
        else
        {
            lucesPuzzle.ResetCode();
            StartCoroutine(TurnOffLights());

        }
    }

    private IEnumerator TurnOffLights()
    {
        yield return new WaitForSeconds(duration);
        luz.SetActive(false);
    }


}