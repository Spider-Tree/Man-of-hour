using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;


public class GoblinAi : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

   [SerializeField] public float health, maxhealth = 5f;

   private void Start()
   {
       health = maxhealth;
   }

   // attack weapon
    public GameObject Sword;

    public bool CanAttack = true;

    public float AttackCooldown = 1.0f;
    
    // patroling
    public Vector3 walkPoint;
    private bool walkPointSet;
    public float walkPointRange;
    
    //attacking
    public float timeBetweenAttacks;
    private bool alreadyAttacked;
    
    //states
    public float sightRange, AttackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("PlayerObj").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, AttackRange, whatIsPlayer);
        
        if(!playerInSightRange && !playerInAttackRange) Patroling();
        if(playerInSightRange && !playerInAttackRange) ChasePlayer();
        if(playerInSightRange && playerInAttackRange) AttackPlayer();
    }

    private void Patroling()
    {
        if(!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination((walkPoint));
        
        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        
        //walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
     //calculate random point in range
     float randomZ = Random.Range(-walkPointRange, walkPointRange);
     float randomX = Random.Range(-walkPointRange, walkPointRange);

     walkPoint = new Vector3(transform.position.x + randomX, 
         transform.position.y, transform.position.z + randomZ);

     if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
         walkPointSet = true;
    }
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }
    private void AttackPlayer()
    {
        //make sure enemy doesn't move
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            //attack code here
            if (playerInAttackRange)
            {
                
            }
                
            // reset attack
            alreadyAttacked = true;
                Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount; 
        
        if (health <= 0) Invoke(nameof(DestroyEnemy), .5f);
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.grey;
        Gizmos.DrawWireSphere(transform.position, AttackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
