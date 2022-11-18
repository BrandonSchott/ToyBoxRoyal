using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent agent;

    [SerializeField]
    GameObject target;

    bool attacking;

    float aimTime, cooldown;
    Rigidbody rb;

    Animator myAnimator;

    Vector3 playerLastPosition;

    enum State
    {
        Idle,
        TargetFound,
        Charging,
        Attack,
        CoolDown
    }
    [SerializeField]
    State enemyState;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        aimTime = Time.time;
        rb = GetComponent<Rigidbody>();
        cooldown = Time.time - 3;
        myAnimator = GetComponent<Animator>();
        enemyState = State.Idle;
    }
    void Update()
    {
        switch (enemyState)
        {
            case State.Idle:
                agent.speed = 0;
                agent.destination = transform.position;
                if (Vector3.Distance(this.transform.position, target.transform.position) < 15)
                {
                    enemyState = State.TargetFound;
                }
                break;
            case State.TargetFound:
                agent.speed = 3.5f;
                agent.destination = target.transform.position;
                if (Vector3.Distance(this.transform.position, target.transform.position) < 5)
                {
                    aimTime = Time.time;
                    agent.speed = 0;
                    enemyState = State.Charging;
                }
                break;
            case State.Charging:
                agent.destination = target.transform.position;
                if (Time.time > aimTime + 1.5)
                {
                    agent.speed = 10;
                    playerLastPosition = target.transform.position;
                    enemyState = State.Attack;
                }
                break;
            case State.Attack:
                agent.destination = playerLastPosition;
                if(Vector3.Distance(this.transform.position, playerLastPosition) < 1)
                {
                    agent.speed = 0;
                    cooldown = Time.time;
                    enemyState = State.CoolDown;
                }
                break;
            case State.CoolDown:
                if(Time.time > cooldown + 2)
                {
                    enemyState = State.Idle;
                }
                break;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            if (collision.gameObject.GetComponent<Health>() != null)
            {
                collision.gameObject.GetComponent<Health>().DealDamage(1);
                collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.back * 15;
            }
        }
    }
}
