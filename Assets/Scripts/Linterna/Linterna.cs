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

    [SerializeField] private Weapon flashLightSO;

    private float timer;

    private void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        playerHUD = FindObjectOfType<PlayerHUD>();
        cam = Camera.main;
    }

    private int range = 8;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            LightFunc();
        }

        if (luzLinterna.enabled)
        {
            RaycastHit hit;


            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
            {

                if (hit.collider.tag == "Enemy" || hit.collider.tag == "GhostHitBox")
                {
                    playerStats.enemySpawned = false;
                    Destroy(hit.transform.gameObject);
                    playerStats.StopPoison();

                }
            }

            playerHUD.ReduceMagazine();
            timer += Time.deltaTime;
            if(timer > 1)
            {
                timer = 0;
                flashLightSO.magazineSize -= 1;
                SpendBattery battery = new SpendBattery();
                battery.spendBattery(flashLightSO.magazineSize, luzLinterna);

                if(flashLightSO.magazineSize <= 0)
                {
                    flashLightSO.magazineSize = 0;
                }
            }
        }
    }

    private void LightFunc()
    {
        activeLight = !activeLight;
        if (activeLight == true)
        {
            luzLinterna.enabled = true;
        }
        else if (activeLight == false)
        {
            luzLinterna.enabled = false;
        }
    }
}
public struct SpendBattery
{
    public void spendBattery(int currBattery, Light light)
    {
        if (currBattery <= 0) light.enabled = false;
    }
}