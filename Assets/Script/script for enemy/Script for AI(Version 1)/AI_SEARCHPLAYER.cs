using UnityEngine;
using UnityEngine.AI;

public class AI_SEARCHPLAYER : MonoBehaviour
{
    public float sightRange = 10f;
    public Transform playerTransform;
    public NavMeshAgent navMeshAgent;
    public float timer;
    public int behaviorState = 0;
    public float stalkSpeed = 1f;
    public float chaseSpeed = 3f;
    public float searchTime = 5f;


    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        switch (behaviorState)
        {
            case 0: // Stalking
                navMeshAgent.speed = stalkSpeed;
                navMeshAgent.SetDestination(playerTransform.position);
                if (CanSeePlayer())
                {
                    behaviorState = Random.Range(1, 3);
                }
                break;

            case 1: // Chasing
                navMeshAgent.speed = chaseSpeed;
                navMeshAgent.SetDestination(playerTransform.position);
                if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
                {
                    KillPlayer();
                }
                else if (!CanSeePlayer())
                {
                    behaviorState = 0;
                }
                break;

            case 2: // Searching
                navMeshAgent.speed = searchTime;
                timer += Time.deltaTime;
                if (timer >= 5f) // Wait for 5 seconds before searching a new spot
                {
                    Vector3 randomDirection = Random.insideUnitSphere * sightRange;
                    randomDirection += playerTransform.position;
                    NavMeshHit hit;
                    NavMesh.SamplePosition(randomDirection, out hit, sightRange, 1);
                    navMeshAgent.SetDestination(hit.position);
                    timer = 0f;
                }
                if (CanSeePlayer())
                {
                    behaviorState = Random.Range(1, 3);
                }
                break;
        }
    }

    public bool CanSeePlayer()
    {
        RaycastHit hit;
        Vector3 rayDirection = playerTransform.position - transform.position;
        if (Physics.Raycast(transform.position, rayDirection, out hit, sightRange))
        {
            if (hit.collider.tag == "Player")
            {
                return true;
            }
        }
        return false;
    }

    public void KillPlayer()
    {
        Debug.Log("killed");
        // Kill the player by disabling the player's game object
        playerTransform.gameObject.SetActive(false);
        // Do other things as necessary, like restarting the level or displaying a game over screen
        // ...
       
    }
}
