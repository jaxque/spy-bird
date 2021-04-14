using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Guard_AI : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform spawnpoint;

    public Transform[] waypoints;
    int currentWaypoint = 0;

    enum GuardState { Patrol, Pursue };
    GuardState currentState = GuardState.Patrol;

    NavMeshAgent navMA;
    GameObject playerTarget;

    public Text CaughtMsg;
    private float timeAppear = 3f;
    private float timeDisappear;

    // Start is called before the first frame update
    void Start()
    {
        navMA = GetComponent<NavMeshAgent>();
        navMA.SetDestination(waypoints[currentWaypoint].position);

        CaughtMsg.enabled = false;
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
                    currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
                    navMA.SetDestination(waypoints[currentWaypoint].position);
                }
                break;
            case GuardState.Pursue:
                break;
            default:
                break;
        }

        // Caught message disappears
        if (CaughtMsg.enabled && (Time.time >= timeDisappear))
        {
            CaughtMsg.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Guard detects player
        if (other.gameObject.tag == "Player")
        {
            playerTarget = other.gameObject;
            SwitchToState(GuardState.Pursue);
        }

        // Guard catches player
        if (other.CompareTag("Player"))
        {
            playerTarget.transform.position = spawnpoint.transform.position;
            Physics.SyncTransforms();

            // Caught message appears
            CaughtMsg.enabled = true;
            timeDisappear = Time.time + timeAppear;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerTarget = other.gameObject;
            SwitchToState(GuardState.Patrol);
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

