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
        ghostPositions.Add(ghostSpawn.position = new Vector3(11, 11.5f, 35));
        ghostPositions.Add(ghostSpawn.position = new Vector3(14, 11.5f, 40));
        ghostPositions.Add(ghostSpawn.position = new Vector3(3, 11.5f, 44));
        ghostPositions.Add(ghostSpawn.position = new Vector3(-1, 11.5f, 59));
        ghostPositions.Add(ghostSpawn.position = new Vector3(10, 11.5f, 64));

        //Trigger Spawns
        triggerPositions.Add(triggerSpawn.position = new Vector3(16.5f, 11.5f, 35f));
        triggerPositions.Add(triggerSpawn.position = new Vector3(11, 11.5f, 41));
        triggerPositions.Add(triggerSpawn.position = new Vector3(2, 11.5f, 34));
        triggerPositions.Add(triggerSpawn.position = new Vector3(-4, 11.5f, 55));
        triggerPositions.Add(triggerSpawn.position = new Vector3(9.5f, 11.5f, 63));

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

            //Player Collide with the trigger
            Debug.Log("Pasando por el trigger");

            //Spawn Enemy
            Instantiate(ghost, ghostSpawn.position, ghostSpawn.rotation);
            enemySpawned = true;
            ghostSpawn.position = ghostPositions[counter];

            //Destroy Collider
            Destroy(collider);

            //Spawn next trigger
            Instantiate(triggerPrefab, triggerSpawn.position, Quaternion.identity);
            triggerSpawn.position = triggerPositions[counter];

            counter++;

            Debug.Log("Pasaste por el Vector3 n: " + counter);


                //if (counter < triggerPositions.Count)
                //{
                //    //Spawn Enemy
                //    Instantiate(ghost, ghostPositions[counter], Quaternion.identity);
                //    enemySpawned = true;

                //    //Destroy Collider
                //    //triggerPositions.Remove(position);

                //    //Spawn next trigger
                //    Instantiate(triggerPrefab, position, Quaternion.identity);

                //    counter = counter + 1;

                //    Debug.Log("Pasaste por el Vector3 n: " + counter);
                //}
            };
            //for(int i = 0; i < triggerPositions.Count; i++)
            //{
            //    //Spawn Enemy
            //    Instantiate(ghost, ghostPositions[i], Quaternion.identity);
            //    enemySpawned = true;

            //    //Destroy Collider
            //    triggerPositions.RemoveAt(i);

            //    //Spawn next trigger
            //    Instantiate(triggerPrefab, triggerPositions[i], Quaternion.identity);

            //    i++;

            //    Debug.Log("Pasaste por el Vector3 n: " + i);
            //}
                //if (counter < triggerPositions.Count)
                //{
                //    //Spawn Enemy
                //    Instantiate(ghost, ghostPositions[counter], Quaternion.identity);
                //    enemySpawned = true;

                //    //Destroy Collider
                //    triggerPositions.RemoveAt(counter);

                //    //Spawn next trigger
                //    Instantiate(triggerPrefab, triggerPositions[counter], Quaternion.identity);

                //    counter++;

                //    Debug.Log("Pasaste por el Vector3 n: " + counter);
                //}
            
            

        



        //Instantiate(ghost, ghostPositions[0], ghostSpawn.rotation);
        //enemySpawned = true;
        //Destroy(collider);

        //TODO: SWITCH para que cada vez que toca un trigger cambie a la siguiente posicion:
        //ghostSpawn.position = new Vector3(3, 11, 44);
        //ghostSpawn.position = new Vector3(-1, 11, 59);
        //ghostSpawn.position = new Vector3(10, 12, 64);
        //Destroy(collider);






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

