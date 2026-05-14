using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using JetBrains.Annotations;

public class NavMesh : MonoBehaviour
{
    public Transform player;
    public float rangoPlayer = 15f;
    public NavMeshAgent agent;

    public Transform[] waypoints;
    public float waypointDistance = 1f;
    public int currentWaypoint = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (waypoints.Length > 0)
        {
            agent.SetDestination(waypoints[currentWaypoint].position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float distancia = Vector3.Distance(transform.position, player.position);

        if (distancia < rangoPlayer)
        {
            agent.SetDestination(player.position);
        }
        else
        {
            if(!agent.pathPending && agent.remainingDistance <= waypointDistance)
            {
                GoToNextWaypoint();
            }
        }

    }

    void GoToNextWaypoint()
    {
        currentWaypoint++;

        if (currentWaypoint >= waypoints.Length)
        {
            currentWaypoint = 0;
        }
        agent.SetDestination(waypoints[currentWaypoint].position);
    }
}
