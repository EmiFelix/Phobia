using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private Transform player, enemigo;

    [SerializeField] private float velocidad;

    public bool seguimiento;

    private Vector3 playerPos;

    private void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        playerPos = new Vector3(player.position.x, enemigo.position.y, player.position.z);
        if (seguimiento == true)
        {
            enemigo.transform.position = Vector3.MoveTowards(transform.position, playerPos, velocidad * Time.deltaTime);
            enemigo.transform.LookAt(player);
        }
    }
}
