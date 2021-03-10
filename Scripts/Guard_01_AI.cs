using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Guard_01_AI : MonoBehaviour
{
    public Transform[] waypoints;

    int currentWaypoint = 0;

    enum GuardState {Patrol, Pursue};
    GuardState currentState = GuardState.Patrol;

    NavMeshAgent navMA;

    // Start is called before the first frame update
    void Start()
    {
        navMA = GetComponent<NavMeshAgent>();
        navMA.SetDestination(waypoints[currentWaypoint].position);
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case GuardState.Patrol:
                if (navMA.remainingDistance < 0.04f)
                {
                    currentWaypoint = (currentWaypoint +1) % waypoints.Length;
                    navMA.SetDestination(waypoints[currentWaypoint].position);
                }
                break;
            case GuardState.Pursue:
                break;
            default:
                break;
        }
    }
}
