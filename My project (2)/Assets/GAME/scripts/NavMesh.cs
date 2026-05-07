using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using JetBrains.Annotations;

public class NavMesh : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;
    public Transform startPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distancia = Vector3.Distance(transform.position, player.position);
        Debug.Log(distancia);

        if (distancia < 20f)
        {
            agent.destination = player.position;
        }
        else
        {
            agent.destination = startPoint.position;
        }

    }
}
