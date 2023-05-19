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
    //[SerializeField] private GameObject player;

    public bool enemySpawned;

    public List<Vector3> ghostPositions = new List<Vector3>();
    public List<Vector3> triggerPositions = new List<Vector3>();

    private int counter = 0;

    private void Start()
    {
        GetReferences();
        InitVariables();

        //Enemy Spawns
        ghostPositions.Add(ghostSpawn.position = new Vector3(11, 12, 35));
        ghostPositions.Add(ghostSpawn.position = new Vector3(14, 13, 41));
        ghostPositions.Add(ghostSpawn.position = new Vector3(3, 11, 44));
        ghostPositions.Add(ghostSpawn.position = new Vector3(-1, 11, 59));
        ghostPositions.Add(ghostSpawn.position = new Vector3(10, 12, 64));

        //Trigger Spawns
        triggerPositions.Add(triggerSpawn.position = new Vector3(16.5f, 12.5f, 35f));
        triggerPositions.Add(triggerSpawn.position = new Vector3(11, 12.5f, 41));

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
    private void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Player"))
        {

            //Player Collide with the trigger
            Debug.Log("Pasando por el trigger");

            if (counter < triggerPositions.Count)
            {
                //Spawn Enemy
                Instantiate(ghost, ghostPositions[counter], Quaternion.identity);
                enemySpawned = true;

                //Destroy Collider
                Destroy(GetComponent<Collider>());

                //Spawn next trigger
                Instantiate(triggerPrefab, triggerPositions[counter], Quaternion.identity);

                counter++;
            }

        }
       
        

        //Instantiate(ghost, ghostPositions[0], ghostSpawn.rotation);
        //enemySpawned = true;
        //Destroy(collider);

        //TODO: SWITCH para que cada vez que toca un trigger cambie a la siguiente posicion:
        //ghostSpawn.position = new Vector3(3, 11, 44);
        //ghostSpawn.position = new Vector3(-1, 11, 59);
        //ghostSpawn.position = new Vector3(10, 12, 64);
        //Destroy(collider);

    




        if (other.transform.tag == "GhostHitBox")
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

