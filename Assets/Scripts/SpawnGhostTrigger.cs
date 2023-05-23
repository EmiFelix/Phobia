using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGhostTrigger : MonoBehaviour
{
    public Transform ghostPos;
    public GameObject ghostOb;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameObject currentGhost = Instantiate(ghostOb);
            currentGhost.transform.parent = null;
            currentGhost.transform.position = ghostPos.position;
            Destroy(this.gameObject);
        }
    }

}
