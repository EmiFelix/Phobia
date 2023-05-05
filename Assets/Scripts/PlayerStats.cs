using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    private PlayerHUD hud;

    //trigger
    [SerializeField] private LayerMask trigger;

    [SerializeField] private GameObject ghost;
    [SerializeField] private GameObject triggerEmpty;
    [SerializeField] private Transform ghostSpawn;

    public bool enemySpawned;

    private void Start()
    {
        GetReferences();
        InitVariables();

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
            Instantiate(ghost, ghostSpawn.position, ghostSpawn.rotation);
            enemySpawned = true;
            ghostSpawn.position = new Vector3(14, 13, 41);

            //TODO: SWITCH para que cada vez que toca un trigger cambie a la siguiente posicion:
            //ghostSpawn.position = new Vector3(3, 11, 44);
            //ghostSpawn.position = new Vector3(-1, 11, 59);
            //ghostSpawn.position = new Vector3(10, 12, 64);
            Destroy(collider);
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

