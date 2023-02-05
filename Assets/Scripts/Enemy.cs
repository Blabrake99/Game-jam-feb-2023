using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IDamageble
{

    // variables for patrolling enemy
    private NavMeshAgent agent;
    [SerializeField] List<Transform> waypoints;
    int waypointIndex;
   
    // variables for all enemies
    public GameObject player;
    Animator anim;
    [SerializeField] int health = 5;
    public int Health { get { return health; } set { health = value; } }

    [SerializeField]
   private float range;


    // variables for stationary enemy
    [SerializeField]
    private float shootCD;

    // variables for hopping enemies
    [SerializeField]
    float hopSpeed = 2f;
    bool goingUp = true;

    [SerializeField] Vector3 moveDistance;
    Vector3 startPos, EndPos;
    List<Rigidbody> rigidbodies = new List<Rigidbody>();
    Transform _transform;
    Vector3 lastPos;

    public enum EnemyType
    {
        PATROL,
        SITTING,
        HOP,
    }
    
    // projectile variables
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

        _transform = transform;
        startPos = _transform.position;
        lastPos = _transform.position;
        EndPos = startPos + moveDistance;

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
            case EnemyType.HOP:
                float step = hopSpeed * Time.deltaTime;
                if (goingUp)
                {
                    _transform.position = Vector3.MoveTowards(_transform.position, EndPos, step);
                    if (Vector3.Distance(_transform.position, EndPos) < 0.1f)
                    {
                        goingUp = false;
                    }
                }
                else
                {
                    _transform.position = Vector3.MoveTowards(_transform.position, startPos, step);
                    if (Vector3.Distance(_transform.position, startPos) < 0.1f)
                    {
                        goingUp = true;
                    }
                }
                if (rigidbodies.Count > 0)
                {
                    for (int i = 0; i < rigidbodies.Count; i++)
                    {
                        if (rigidbodies[i] != null)
                        {
                            Rigidbody rb = rigidbodies[i];
                            Vector2 vel = new Vector2((_transform.position.x - lastPos.x) + ((rb.velocity.x * Time.deltaTime) / 2),
                                                      (_transform.position.y - lastPos.y) + ((rb.velocity.y * Time.deltaTime) / 2));
                            rb.transform.Translate(vel, transform);
                        }
                    }
                }
                lastPos = _transform.position;
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
