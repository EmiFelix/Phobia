using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactuar : MonoBehaviour
{
    public GameObject luzObjeto;
    public bool luz;
    public bool luzOnOff;

    public void OnOffLuz()
    {
        luzOnOff = !luzOnOff;

        if(luzOnOff == true)
        {
            luzObjeto.SetActive(true);
        } 
        else if (luzOnOff == false)
        {
            luzObjeto.SetActive(false);
        }
    }

}
