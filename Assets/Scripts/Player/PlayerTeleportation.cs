using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleportation : MonoBehaviour
{
    public Transform player;
    public float teleportCooldown = 0f;
    public Vector3 arenaCenter;
    public float arenaRadius;

    public static bool canTeleport = true;

    // Store the teleportation coordinates
    public Vector3[] teleportCoordinates;

    private void Start()
    {
        teleportCoordinates = new Vector3[]
        {
            new Vector3(3.7f, 0.176f, 0.041f),
            new Vector3(-3.7f, 0.176f, 0.041f),
            new Vector3(0.019f, 0.176f, 3.751f),
            new Vector3(0.019f, 0.176f, -3.51f),
            new Vector3(2.827f, 0.176f, -2.403f),
            new Vector3(2.321f, 0.176f, 2.656f),
            new Vector3(-0.005f, 0.176f, 3.4851f)
        };
    }

    void Update()
    {
        // Check if the player is outside the arena
        if (Vector3.Distance(player.position, arenaCenter) > arenaRadius)
        {
            // Teleport the player if allowed
            if (canTeleport)
            {
                TeleportPlayer();
                StartCoroutine(TeleportCooldown());
            }
        }
    }

    void TeleportPlayer()
    {
        // Choose a random coordinate from the teleportCoordinates array
        Vector3 randomPosition = teleportCoordinates[Random.Range(0, teleportCoordinates.Length)];

        // Set the player's position to the chosen random coordinate
        player.position = randomPosition;
    }

    Vector3 GetRandomPositionInArena()
    {
        Vector3 randomDirection = Random.insideUnitSphere * arenaRadius;
        randomDirection.y = 0;
        return arenaCenter + randomDirection;
    }

    IEnumerator TeleportCooldown()
    {
        canTeleport = false;
        yield return new WaitForSeconds(teleportCooldown);
        canTeleport = true;
    }
}
