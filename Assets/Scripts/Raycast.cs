using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public int rango;
    public bool fusible2 = true;
    public bool fusible2Espectro = true;
    public Camera camara;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, rango))
        {
            if (hit.collider.GetComponent<CajaFusible>() == true)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (fusible2 == true)
                    {
                        hit.collider.GetComponent<CajaFusible>().fusible2();                    
                    }
                }

            }

            if (hit.collider.GetComponent<Interactuar>() == true)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (hit.collider.GetComponent<Interactuar>().luz == true)
                    {
                        hit.collider.GetComponent<Interactuar>().OnOffLuz();
                    }
                }
            }
        }


        
    }
}