using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;


public class enemySight : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    //patroling
    public Vector3 walkPoint;
    bool walkPoinSet;
    public float walkPointRange;

    //attacking
    public float timeBetweenAttacks;
    bool alreadyAttack;

    //status 
    public float sightRange, attackRage;
    public bool playerInSightRange, playerInAttackRange;


     private void Awake() {
        player = GameObject.Find("player").transform;

    }

    private void Update() {
        //checking player position
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer) ;
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRage, whatIsPlayer) ;
    
        if(!playerInSightRange && !playerInAttackRange) Patroling();
        if(playerInSightRange && !playerInAttackRange) ChasePlayer();
        if(playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    private void Patroling(){
        if(!walkPoinSet) SearchWalkPoint();
        
        if(walkPoinSet) agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if(distanceToWalkPoint.magnitude< 1f)
        walkPoinSet= false;

    }
    
    private void ChasePlayer(){
        agent.SetDestination(player.position);
    }

    private void AttackPlayer(){
        //make sure enemy doesnt move
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if(!alreadyAttack){
            // attack player
            
            
            Debug.Log("Attacking........");
            alreadyAttack = true;
            
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }

    }
    void ResetAttack(){
        alreadyAttack = false;
    }

    void SearchWalkPoint(){
        // because we are nt flying
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z+randomZ);
        
        // walkPoint in Range or not

        if(Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPoinSet= true;
    }
   
}
