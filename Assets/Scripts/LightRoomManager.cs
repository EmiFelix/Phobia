using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRoomManager : MonoBehaviour
{
    [SerializeField] private GameObject lights;
    private bool lightsOn;

    public void LightsInteract()
    {

        if(lightsOn)
        {
            lights.SetActive(true);
            lightsOn = false;
        }
        else
        {
            lights.SetActive(false);
            lightsOn = true;
        }
    }
}
