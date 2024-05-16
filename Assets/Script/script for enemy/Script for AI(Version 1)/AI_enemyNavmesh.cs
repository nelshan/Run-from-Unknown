using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_enemyNavmesh : MonoBehaviour
{
    public enum BehaviorState
    {
         Stalking, 
         Chasing, 
         Hiding 
    };

    public float stalkSpeed = 2f; // speed of the enemy when stalking
    public float chaseSpeed = 4f; // speed of the enemy when chasing
    public float hideTime = 3f; // time the enemy spends in hiding
    public float hideDistance = 10f; // distance from player the enemy runs to when hiding
    public float minIdleTime = 1f; // minimum time the enemy stays in the idle state
    public float maxIdleTime = 3f; // maximum time the enemy stays in the idle state
    public float sightRange = 20f; // range at which the enemy can see the player

    public NavMeshAgent agent;
    private BehaviorState state = BehaviorState.Stalking;
    private Vector3 hidePosition;
    private bool isHiding = false;
    private float idleTime;

    public GameObject player;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");

        idleTime = Random.Range(minIdleTime, maxIdleTime);
        hidePosition = RandomNavSphere(transform.position, hideDistance, -1);
    }

    void Update()
    {
        switch (state)
        {
            case BehaviorState.Stalking:
                agent.speed = stalkSpeed;
                agent.SetDestination(player.transform.position);

                // check if enemy should enter hiding state
                if (Random.value < 0.5f && CanSeePlayer())
                {
                    state = BehaviorState.Hiding;
                    isHiding = true;
                }

                // check if enemy should enter chasing state
                if (CanSeePlayer())
                {
                    state = BehaviorState.Chasing;
                }
                break;

            case BehaviorState.Chasing:
                agent.speed = chaseSpeed;
                agent.SetDestination(player.transform.position);

                // check if enemy should enter hiding state
                if (Random.value < 0.5f && CanSeePlayer())
                {
                    state = BehaviorState.Hiding;
                    isHiding = true;
                }

                // check if enemy should return to stalking state
                if (!CanSeePlayer())
                {
                    state = BehaviorState.Stalking;
                    idleTime = Random.Range(minIdleTime, maxIdleTime);
                }
                break;

            case BehaviorState.Hiding:
                if (isHiding)
                {
                    agent.speed = chaseSpeed;
                    agent.SetDestination(hidePosition);
                    isHiding = false;
                }

                // check if enemy should return to stalking state
                if (idleTime <= 0f)
                {
                    state = BehaviorState.Stalking;
                    idleTime = Random.Range(minIdleTime, maxIdleTime);
                    hidePosition = RandomNavSphere(transform.position, hideDistance, -1);
                }
                else
                {
                    idleTime -= Time.deltaTime;
                }
                break;
        }
    }

    // check if the enemy can see the player within the sight range
    bool CanSeePlayer()
    {
        Vector3 direction = player.transform.position - transform.position;
        float angle = Vector3.Angle(direction, transform.forward);
        if (angle < 60f)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, direction.normalized, out hit, sightRange))
            {
                if (hit.collider.gameObject == player)
                {
                    return true;
                }
            }
        }
        return false;
    }

    // helper function to get a random
    Vector3 RandomNavSphere(Vector3 origin, float distance, int layermask)
    {
        Vector3 randomDirection = Random.insideUnitSphere * distance;
        randomDirection += origin;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection, out navHit, distance, layermask);
        return navHit.position;
    }
}
