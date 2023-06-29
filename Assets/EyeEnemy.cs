using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EyeEnemy : MonoBehaviour
{
    [SerializeField] private float _hp;

    public NavMeshAgent agent;
    public Transform bodoque;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer, obstacleLayer;


    public Vector3 walkPoint;
    bool WalkPointSet;
    public float walkPointRange;

    public float timeBetweenAttacks;
    public bool alreadyAttacked;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    //public Animator _Anim;

    string _xAxisName = "X Axis";
    string _zAxisName = "Z Axis";

    float _xAxis, _zAxis;

    Vector3 actualObj;
    bool isMoving;

    public AudioSource playerAttacked;

    private bool isDashing = false;
    public float dashSpeed = 10f;
    public float dashDuration = 0.5f;

    public void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        playerAttacked = GetComponent<AudioSource>();

    }

    void AnimatorManager(float xAxis, float zAxis)
    {
        //_Anim.SetFloat(_xAxisName, xAxis);
        //_Anim.SetFloat(_zAxisName, zAxis);
    }

    public void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(bodoque.position, player.transform.position, out hit, sightRange, whatIsPlayer))
        {
            Debug.Log(1);
            float magnitude = (hit.point - bodoque.position).magnitude;
            if (!Physics.Raycast(bodoque.position, player.transform.position, magnitude * 0.9f, obstacleLayer))
            {
                Debug.Log(2);
                playerInSightRange = true;
            }
            else playerInSightRange = false;

        }

        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange)
        {
            if (!isDashing) // Only patrol when not dashing
                Patroling();
        }
        if (playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer();
            //playerAttacked.Play();
        }
        if (playerInSightRange && playerInAttackRange)
            AttackPlayer();

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

        //AnimatorManager(_xAxis, _zAxis);
    }

    private void Patroling()
    {
        if (!WalkPointSet)
            SearchWalkPoint();

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

        StartCoroutine(DashToPlayer());

        Vector3 lookAt = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.LookAt(lookAt);

        if (!alreadyAttacked)
        {
            agent.isStopped = true;

            
            

            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private IEnumerator DashToPlayer()
    {
        isDashing = true;

        
        Vector3 dashDirection = (player.position - transform.position).normalized;

        
        float dashTimer = 0f;
        while (dashTimer < dashDuration)
        {
            agent.velocity = dashDirection * dashSpeed;
            dashTimer += Time.deltaTime;
            yield return null;
        }

        
        agent.velocity = Vector3.zero;
        isDashing = false;
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
        isMoving = true;
        agent.isStopped = false;
    }

    public void LoseHP(float damage)
    {
        _hp -= damage;

        if (_hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}