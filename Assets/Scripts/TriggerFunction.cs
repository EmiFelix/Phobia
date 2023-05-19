using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFunction : MonoBehaviour
{
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
    // Start is called before the first frame update
    void Start()
    {
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

    private void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Trigger"))
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

    }
}
