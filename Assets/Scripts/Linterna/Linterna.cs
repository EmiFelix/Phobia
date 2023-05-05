using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Linterna : MonoBehaviour
{
    public Light luzLinterna;
    public bool activeLight;

    public PlayerHUD playerHUD;

    public Camera cam;

    [SerializeField] private GameObject enemy;

    [SerializeField] private PlayerStats playerStats;

    private void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        playerHUD = FindObjectOfType<PlayerHUD>();
        cam = Camera.main;
    }

    private int rango = 8;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            LightFunc();
        }

        if (luzLinterna.enabled)
        {
            playerHUD.ReduceMagazine();
        }
    }

    private void LightFunc()
    {
        activeLight = !activeLight;
        if (activeLight == true)
        {
            luzLinterna.enabled = true;

            
            RaycastHit hit;


            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, rango))
            {

                if (hit.collider.tag == "Enemy" || hit.collider.tag == "GhostHitBox")
                {
                    playerStats.enemySpawned = false;
                    Destroy(hit.transform.gameObject);
                    playerStats.StopPoison();

                }
            }
        }
        else if (activeLight == false)
        {
            luzLinterna.enabled = false;
        }
    }
}
