using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class AI_enemy : MonoBehaviour
{
    public float sightRange = 10f;
    public float searchTime = 5f;
    public float walkSpeed = 1.5f;
    public float runSpeed = 4f;

    public NavMeshAgent navMeshAgent;
    public GameObject player;
    private float searchTimer;
    private bool isSearching;
    private Vector3 searchLocation;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        isSearching = false;
        searchLocation = Vector3.zero;
    }

    void Update()
    {
        if (CanSeePlayer())
        {
            if (Random.value < 0.5f)
            {
                ChasePlayer();
            }
            else
            {
                SearchForPlayer();
            }
        }
        else if (isSearching)
        {
            navMeshAgent.SetDestination(searchLocation);
            if (Vector3.Distance(transform.position, searchLocation) < 1f)
            {
                isSearching = false;
                if (Random.value < 0.5f)
                {
                    KillPlayer();
                }
                else
                {
                    GoToRandomLocation();
                }
            }
        }
        else
        {
            navMeshAgent.speed = walkSpeed;
            navMeshAgent.SetDestination(player.transform.position);
        }
    }

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

    void ChasePlayer()
    {
        navMeshAgent.speed = runSpeed;
        navMeshAgent.SetDestination(player.transform.position);
    }

    void SearchForPlayer()
    {
        isSearching = true;
        navMeshAgent.speed = walkSpeed;
        searchTimer = searchTime;
        searchLocation = player.transform.position + Random.insideUnitSphere * sightRange;
        searchLocation.y = 0;
    }

    void KillPlayer()
    {
        navMeshAgent.speed = runSpeed;
        navMeshAgent.SetDestination(player.transform.position);
    }

    void GoToRandomLocation()
    {
        Vector3 randomDirection = Random.insideUnitSphere * sightRange;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, sightRange, 1);
        navMeshAgent.SetDestination(hit.position);
    }
}
