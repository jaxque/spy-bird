using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Guard_01_AI : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform spawnpoint;

    public Transform[] waypoints;

    public float Timer = 0;

    int currentWaypoint = 0;

    enum GuardState {Patrol, Pursue};
    GuardState currentState = GuardState.Patrol;

    NavMeshAgent navMA;

    GameObject playerTarget;

    // Start is called before the first frame update
    void Start()
    {
        navMA = GetComponent<NavMeshAgent>();
        navMA.SetDestination(waypoints[currentWaypoint].position);
    }

    void SwitchToState(GuardState newState)
    {
        switch (newState)
        {
            case GuardState.Patrol:
                break;
            case GuardState.Pursue:
                navMA.SetDestination(playerTarget.transform.position);
                break;
            default:
                break;
        }
        currentState = newState;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            playerTarget = other.gameObject;
            SwitchToState(GuardState.Pursue);
            Timer++; 
        }

        if (other.CompareTag("Player") && Timer > 10)
        {
            player.transform.position = spawnpoint.transform.position;
            Physics.SyncTransforms();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerTarget = other.gameObject;
            SwitchToState(GuardState.Patrol);
            //Timer = 0;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            Debug.Log("Hit");
        }
    }
}

