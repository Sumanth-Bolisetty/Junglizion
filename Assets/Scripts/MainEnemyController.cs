using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
/*
public GameObject treasureBox;
public GameObject Hero;
private Animator mainEnemyAnim;
private Quaternion enemyRot;
[SerializeField] private bool isAttacking;
[SerializeField] private float speed = 10;
public int health = 100;

// Start is called before the first frame update
void Start()
{
    mainEnemyAnim = GetComponent<Animator>();
    enemyRot = transform.rotation;
}

// Update is called once per frame
void Update()
{
    if (Hero.transform.position.x - transform.position.x < 5 && Hero.transform.position.z - transform.position.z < 5 &&
               Hero.transform.position.x - transform.position.x > -5 && Hero.transform.position.z - transform.position.z > -5)
    {
        transform.LookAt(Hero.transform.position);
        mainEnemyAnim.SetTrigger("Attack");
        isAttacking = true;
    }
    else
        isAttacking = false;
    if (!isAttacking)
    {
        transform.RotateAround(treasureBox.transform.position, Vector3.up, Time.deltaTime * speed);
        mainEnemyAnim.SetTrigger("EnemyWalk");
    }
}*/

public class MainEnemyController : MonoBehaviour
{
    public float patrolTime = 10f;
    public float agroRange = 10f;

    public Transform[] waypoints;
    public int health = 100;
    private int index;

    private float speed, agentSpeed;
    [SerializeField] private Transform player;

    private Animator anim;
    private NavMeshAgent agent;
    private void Awake()

    {
        SoundsManager.PlaySound("stepsMEnemy");
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        if (agent != null) { agentSpeed = agent.speed; }

        index = Random.Range(0, waypoints.Length);

        InvokeRepeating("Tick", 0, 0.5f);

        if (waypoints.Length > 0)

        { InvokeRepeating("Patrol", 0, patrolTime);
        }
    }
    void Patrol()
    {
        index = index == waypoints.Length - 1 ? 0 : index + 1;
    }
    void Tick()
    {
        agent.destination = waypoints[index].position;
        agent.speed = agentSpeed;
        if (player != null && Vector3.Distance(transform.position, player.position) < agroRange)
        {
            agent.destination = player.position;
            agent.speed = agentSpeed/4;
            anim.SetTrigger("Attack");
            
        }
    }

}
