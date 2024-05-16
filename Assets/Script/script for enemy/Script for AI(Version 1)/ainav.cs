using UnityEngine;
using UnityEngine.AI;

public class ainav : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent navMeshAgent;
    //public Animator animator;

    private Vector3 lastKnownPlayerPosition;
    private bool playerInSight;
    private bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        //animator = GetComponent<Animator>();
        lastKnownPlayerPosition = transform.position;

        if (player != null)
        {
            navMeshAgent.SetDestination(player.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            return;
        }

        if (playerInSight)
        {
            navMeshAgent.destination = player.position;

            if (Vector3.Distance(transform.position, player.position) <= 1.0f)
            {
                //animator.SetTrigger("Death");
                isDead = true;
            }
        }
        else
        {
            navMeshAgent.destination = lastKnownPlayerPosition;

            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, (player.position - transform.position).normalized, out hit, 10.0f))
            {
                if (hit.transform.CompareTag("Player"))
                {
                    playerInSight = true;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInSight = false;
            lastKnownPlayerPosition = player.position;
        }
    }
    
}
