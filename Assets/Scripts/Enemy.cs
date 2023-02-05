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

    [SerializeField]
   private float range;

    [SerializeField]
    private float shootCD;

    public enum EnemyType
    {
        PATROL,
        SITTING,
    }
    
    [SerializeField]
    EnemyType type;
    [SerializeField]
    private GameObject projectile;
    public GameObject shootbox;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");

        switch (type)
        {
            case EnemyType.PATROL:
                if (waypoints != null && waypoints.Count >= 2)
                {
                    waypointIndex = 0;
                }
                break;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector3.Distance(gameObject.transform.position, player.gameObject.transform.position);

        switch (type)
        {
            case EnemyType.PATROL:
        if (distanceFromPlayer <= range)
        {
            agent.SetDestination(player.transform.position);
        }
        else if (distanceFromPlayer > range)
        {
            ChangeDestination();
        }

        if (agent.remainingDistance <= 1f)
        {
            ChangeWaypoint();
            ChangeDestination();
        }
                break;
            case EnemyType.SITTING:
                if (distanceFromPlayer <= 7)
                {
                    if (shootCD <= 0)
                    {
                        Instantiate(projectile, shootbox.transform.position, transform.rotation);
                        shootCD = 1;
                    }
                }

                break;
        }

        if(shootCD > 0)
        {
            shootCD -= Time.deltaTime;
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
