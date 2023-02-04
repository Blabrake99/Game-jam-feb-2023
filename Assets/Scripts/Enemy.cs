using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IDamageble
{
    private NavMeshAgent agent;
    [SerializeField] List<Transform> waypoints;
    int waypointIndex;
    public GameObject player;
    Animator anim;
    [SerializeField] int health = 5;
    public int Health { get { return health; } set { health = value; } }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");

        if (waypoints != null && waypoints.Count >= 2)
        {
            waypointIndex = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector3.Distance(gameObject.transform.position, player.gameObject.transform.position);
        Debug.Log(distanceFromPlayer);

        if (distanceFromPlayer <= 7)
        {
            agent.SetDestination(player.transform.position);
        }
        else if (distanceFromPlayer > 7)
        {
            ChangeDestination();
        }

        if (agent.remainingDistance <= 1f)
        {
            ChangeWaypoint();
            ChangeDestination();
        }
    }

    private void ChangeWaypoint()
    {
        waypointIndex++;

        if (waypointIndex >= waypoints.Count)
        {
            waypointIndex = 0;
        }
    }

    private void ChangeDestination()
    {
        if (waypoints != null)
        {
            Vector3 target = waypoints[waypointIndex].transform.position;
            agent.SetDestination(target);
        }
    }

    public void Damage(int amount)
    {
        Health -= amount;
        if (Health < 1)
        {
            gameObject.SetActive(false);
        }
    }
}
