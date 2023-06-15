using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteActivator : MonoBehaviour
{
    public GameObject visualNote;
    private bool active;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && active == true)
        {
            visualNote.SetActive(true);
            
        } else 
        {
            visualNote.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            active = true;
            visualNote.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            active = false;
            visualNote.SetActive(false);
        }
    }
}
