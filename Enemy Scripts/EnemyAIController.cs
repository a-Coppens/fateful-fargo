using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


// Thanks to Brackeys
public class EnemyAIController : MonoBehaviour
{
    public float aggroRange = 25f;
    public bool isAggroed;
    Transform target;
    NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= aggroRange)
        {
            isAggroed = true;
            agent.SetDestination(target.position);
        }
    }

}
