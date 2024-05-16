using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class E_N_Mash : MonoBehaviour
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
    private int playerLayer;
    private int obstacleLayer;

    public GameObject stalkingSoundObject;
    public GameObject chasingSoundObject;
    private AudioSource stalkingAudioSource;
    private AudioSource chasingAudioSource;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponentInChildren<Animator>();
        playerLayer = LayerMask.NameToLayer("Player");
        obstacleLayer = LayerMask.NameToLayer("Obstacle");

        stalkingAudioSource = stalkingSoundObject.GetComponent<AudioSource>();
        chasingAudioSource = chasingSoundObject.GetComponent<AudioSource>();
    }

    private void Start()
    {
        idleTime = Random.Range(minIdleTime, maxIdleTime);
    }

    private void Update()
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

                    // play chasing sound
                    chasingAudioSource.Play();
                }
                else
                {
                    animator.Play("Walk");

                   // play stalking sound
                    if (!stalkingAudioSource.isPlaying)
                    {
                        stalkingAudioSource.Play();
                    }
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

                    // stop playing chasing sound
                    chasingAudioSource.Stop();
                }
                else
                {
                    animator.Play("Run");
                    
                    // play chasing sound
                    if (!chasingAudioSource.isPlaying)
                    {
                        chasingAudioSource.Play();
                    }
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
                Vector3 randomDirection = Random.insideUnitSphere * sightRange;
                randomDirection += transform.position;
                NavMeshHit navHit;
                if (NavMesh.SamplePosition(randomDirection, out navHit, sightRange, NavMesh.AllAreas))
                {
                    agent.SetDestination(navHit.position);
                }
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
            if (Physics.Raycast(transform.position, direction.normalized, out hit, sightRange, 1 << obstacleLayer))
            {
                return false;
            }
            if (Physics.Raycast(transform.position, direction.normalized, out hit, sightRange, 1 << playerLayer))
            {
                if (hit.collider.gameObject == player)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
