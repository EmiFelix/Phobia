using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaFusible : MonoBehaviour
{
    public int fusibles = 5;
    private bool palancaActiva;

    [SerializeField] private GameObject fusibleDos;
    [SerializeField] private GameObject fusible2Espectro;
    [SerializeField] private GameObject interruptor;


    private void Start()
    {
        palancaActiva = false;
    }

    private void Update()
    {
        if (fusibles == 6 )
        {
            palancaActiva = true;
            GetComponent<Interactuar>().luzObjeto.SetActive(true);
        }
       

    }

    public void fusible2()
    {
        fusibles += 1;
        fusibleDos.SetActive(true);
        fusible2Espectro.SetActive(false);
        var x = interruptor.GetComponent<Interactuar>();
        x.luz = true;
    }
}