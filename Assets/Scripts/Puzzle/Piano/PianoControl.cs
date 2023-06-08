using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoControl : MonoBehaviour
{
    public string[] correctCode = { "Do", "Re", "Mi", "Fa" };
    private string[] codeEntered = new string[4];

    private void Update()
    {
        //Verificar si se ingresó el código correcto
        if (codeEntered.SequenceEqual(correctCode))
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        Debug.Log("Opened hehe");
    }

}
