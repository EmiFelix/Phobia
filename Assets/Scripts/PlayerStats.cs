using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    private PlayerHUD hud;

    //trigger
    [SerializeField] private LayerMask trigger;
    [SerializeField] private GameObject ghost;
    [SerializeField] private GameObject triggerPrefab;
    [SerializeField] private Transform ghostSpawn;
    [SerializeField] private Transform triggerSpawn;
    [SerializeField] private LayerMask triggerSound;
    //[SerializeField] private GameObject player;

    public bool enemySpawned;

    public List<Vector3> ghostPositions = new List<Vector3>();
    public List<Vector3> triggerPositions = new List<Vector3>();

    private int counter = 0;

    public AudioSource jumpScare;

    private void Start()
    {
        GetReferences();
        InitVariables();

        //Enemy Spawns
        ghostPositions.Add(ghostSpawn.position = new Vector3(24, 11.5f, 33));
        ghostPositions.Add(ghostSpawn.position = new Vector3(14, 11.5f, 40));
        ghostPositions.Add(ghostSpawn.position = new Vector3(1.5f, 11.5f, 45));
        ghostPositions.Add(ghostSpawn.position = new Vector3(-6.896f, 11.5f, 50.487f));
        ghostPositions.Add(ghostSpawn.position = new Vector3(-6, 11.5f, 68));
        ghostPositions.Add(ghostSpawn.position = new Vector3(11, 11.5f, 57.5f));

        //Trigger Spawns
        triggerPositions.Add(triggerSpawn.position = new Vector3(14.6f, 11.5f, 34.4f));
        triggerPositions.Add(triggerSpawn.position = new Vector3(11, 11.5f, 45));
        triggerPositions.Add(triggerSpawn.position = new Vector3(3.5f, 11.5f, 39));
        triggerPositions.Add(triggerSpawn.position = new Vector3(-4, 11.5f, 53));
        triggerPositions.Add(triggerSpawn.position = new Vector3(1.5f, 11.5f, 57));
        triggerPositions.Add(triggerSpawn.position = new Vector3(10, 11.5f, 63));

    }

    private void GetReferences()
    {
        hud = GetComponent<PlayerHUD>();
    }

    public override void CheckHP()
    {
        base.CheckHP();
        hud.UpdateHP(HP, maxHP);
    }

    //TODO: PLEASE MIGRAR TODAS ESTAS COSAS A UN GAME MANAGER >.<"
    private void OnTriggerEnter(Collider collider)
    {

        if (collider.transform.tag == "Trigger")
        {
            jumpScare.Play();
            Debug.Log("Trigger:");
            Instantiate(ghost, ghostPositions[counter], ghostSpawn.rotation);
            Debug.Log("Spawn fantasma:" + counter);
            enemySpawned = true;
            counter++;
            Destroy(collider);
            Instantiate(triggerPrefab, triggerPositions[counter], triggerSpawn.rotation);
            Debug.Log("Spawn trigger:" + counter);
        }

        if (collider.transform.tag == "GhostHitBox")
        {
            OnPoisoned(); 
        }
    }

    private bool isPoisoned = false;
    private float poisonInterval = 0.5f;

    // Call this method when the player is hit by the enemy's GhostHitBox collider
    private void OnPoisoned()
    {
        if (!isPoisoned)
        {
            isPoisoned = true;             
            StartCoroutine(PoisonCoroutine());
        }
    }

    private IEnumerator PoisonCoroutine()
    {
        while (isPoisoned)
        {
            // Wait for the specified interval before taking damage
            yield return new WaitForSeconds(poisonInterval);
            // Take 1 damage
            takeDMG(1);
           
        }        
    }

    // Call this method to stop the poison effect
    public void StopPoison()
    {
        isPoisoned = false;
    }
}

