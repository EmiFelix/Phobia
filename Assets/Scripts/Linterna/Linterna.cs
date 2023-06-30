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

    private SpendBattery spendBattery = new SpendBattery();

    public AudioSource linterna;

    private void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        playerHUD = FindObjectOfType<PlayerHUD>();
        cam = Camera.main;
    }

    private int range = 8;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && spendBattery.HasBattery(flashLightSO.magazineSize))
        {
            LightFunc();
        }

        if (luzLinterna.enabled)
        {
            RaycastHit hit;
            Debug.Log("entramos en linterna hit");
            

            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
            {
                Debug.Log("entramos en hit");
                Debug.Log(hit.collider.name);
                if (hit.collider.tag == "Enemy" || hit.collider.tag == "GhostHitBox")
                {
                    
                    Debug.Log("entramos en enemy collider o ghost hitbox");
                    var spider = hit.collider.GetComponent<IEnemy>();
                    if (spider != null)
                    {
                        Debug.Log("le bajo hp");
                        spider.LoseHP(10);
                    }

                    playerStats.enemySpawned = false;
                    playerStats.StopPoison();

                }
            }

            playerHUD.ReduceMagazine();
            timer += Time.deltaTime;
            if(timer > 1)
            {
                timer = 0;
                flashLightSO.magazineSize -= 1;

                
                spendBattery.spendBattery(flashLightSO.magazineSize, luzLinterna);

                
            }
        }
    }

    private void LightFunc()
    {
        activeLight = !activeLight;
        if (activeLight == true)
        {
            linterna.Play();
            luzLinterna.enabled = true;
        }
        else if (activeLight == false)
        {
            linterna.Play();
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

    public bool HasBattery(int currBattery)
    {
        if (currBattery > 0)
        {
            return true;
        }
        return false;
    }
}