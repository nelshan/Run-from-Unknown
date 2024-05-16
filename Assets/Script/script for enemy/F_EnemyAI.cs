using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class F_EnemyAI : MonoBehaviour
{
    public enum BehaviorState { Stalking, Chasing };

    public float stalkSpeed = 4f; // speed of the enemy when stalking
    public float chaseSpeed = 9f; // speed of the enemy when chasing
    public float minIdleTime = 0.5f; // minimum time the enemy stays in the idle state
    public float maxIdleTime = 1f; // maximum time the enemy stays in the idle state
    public float sightRange = 20f; // range at which the enemy can see the player

    private NavMeshAgent agent;
    private BehaviorState state = BehaviorState.Stalking;
    private float idleTime;

    private GameObject player;
    private Animator animator;
    private AudioSource audioSource;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponentInChildren<Animator>();
       

        idleTime = Random.Range(minIdleTime, maxIdleTime);
    }

    void Update()
    {
        switch (state)
        {
            case BehaviorState.Stalking:
                agent.speed = stalkSpeed;
                agent.SetDestination(player.transform.position);

                // check if enemy should enter chasing state
                if (CanSeePlayer())
                {
                    state = BehaviorState.Chasing;
                    animator.Play("Run");
                }
                else
                {
                    animator.Play("Walk");
                }
                break;

            case BehaviorState.Chasing:
                agent.speed = chaseSpeed;
                agent.SetDestination(player.transform.position);
                

                // check if enemy should return to stalking state
                if (!CanSeePlayer())
                {
                    state = BehaviorState.Stalking;
                    idleTime = Random.Range(minIdleTime, maxIdleTime);
                    animator.Play("Walk");
                }
                else
                {
                    animator.Play("Run");
                }
                break;
        }

        // reduce idle time in both states
        if (idleTime <= 0f)
        {
            idleTime = Random.Range(minIdleTime, maxIdleTime);

            // if currently stalking, set a new random destination
            if (state == BehaviorState.Stalking)
            {
                agent.SetDestination(RandomNavSphere(transform.position, sightRange, -1));
            }
        }
        else
        {
            idleTime -= Time.deltaTime;
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

    // position on the NavMesh within a certain distance from a given point
    Vector3 RandomNavSphere(Vector3 origin, float distance, int layermask)
    {
        Vector3 randomDirection = Random.insideUnitSphere * distance;
        randomDirection += origin;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection, out navHit, distance, layermask);
        return navHit.position;
    }

    /**void OnDrawGizmos()
    {
        // Draw a wire sphere to represent the sight range
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);

        // Draw a wire sphere to represent the random position on the NavMesh
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(RandomNavSphere(transform.position, sightRange, -1), 1);
    }**/
}
