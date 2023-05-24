using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyScript : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public Vector3 walkPoint;
    bool WalkPointSet;
    public float walkPointRange;

    public float timeBetweenAttacks;
    public bool alreadyAttacked;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public Animator _Anim;

    string _xAxisName = "X Axis";
    string _zAxisName = "Z Axis";

    float _xAxis, _zAxis;

    Vector3 actualObj;
    bool isMoving;

    public void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();


    }

    void AnimatorManager(float xAxis, float zAxis)
    {
        _Anim.SetFloat(_xAxisName, xAxis);
        _Anim.SetFloat(_zAxisName, zAxis);
    }

    public void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();

        Vector3 dir = transform.forward * actualObj.z + transform.right * actualObj.x;
        

        if (isMoving)
        {
            _xAxis = dir.x;
            _zAxis = dir.z;
        }
        else
        {
            _xAxis = 0;
            _zAxis = 0;
        }
        
        AnimatorManager(_xAxis, _zAxis);
    }

    private void Patroling()
    {
        if (!WalkPointSet) SearchWalkPoint();


        if (WalkPointSet)
        {
            agent.SetDestination(walkPoint);
            actualObj = walkPoint;
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
        {
            WalkPointSet = false;
        }

    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX + transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            WalkPointSet = true;
        }
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        actualObj = player.position;
    }
    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        actualObj = player.position;
        isMoving = false;

        Vector3 lookAt = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.LookAt(lookAt);

        if (!alreadyAttacked)
        {
            agent.isStopped = true;

            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
        isMoving = true;
        agent.isStopped = false;
    }
}



