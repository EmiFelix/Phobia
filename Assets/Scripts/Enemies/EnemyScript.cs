using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private Transform Player, enemigo;

    [SerializeField] private float velocidad;

    public bool seguimiento;

    private Vector3 playerPos;

    private void Update()
    {
        playerPos = new Vector3(Player.position.x, enemigo.position.y, Player.position.z);
        if (seguimiento == true)
        {
            enemigo.transform.position = Vector3.MoveTowards(transform.position, playerPos, velocidad * Time.deltaTime);
            enemigo.transform.LookAt(Player);
        }
    }
}
