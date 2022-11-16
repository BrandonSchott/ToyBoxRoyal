using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent agent;

    [SerializeField]
    GameObject target;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Vector3.Distance(this.transform.position, target.transform.position) > 5)
        {
            agent.destination = target.transform.position;
        }
    }
}
