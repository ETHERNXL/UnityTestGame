using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAiBoss : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float desiredDistance = 2f; // Desired distance between player and enemy

    Transform player;
    NavMeshAgent agent;

    // Use this for initialization
    void Start()
    {
        player = EnemyEyes.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.isActiveAndEnabled && agent.isOnNavMesh) // Check if the agent is active and on the NavMesh
        {
            float distance = Vector3.Distance(player.position, transform.position);

            // Calculate the direction from the enemy to the player
            Vector3 toPlayer = player.position - transform.position;

            // Calculate the target position for the enemy to maintain the desired distance
            Vector3 targetPosition = player.position - toPlayer.normalized * desiredDistance;

            // Set the destination for the NavMeshAgent
            agent.SetDestination(targetPosition);

            // Make the enemy face the player
            transform.LookAt(player.position);
        }
    }
}
