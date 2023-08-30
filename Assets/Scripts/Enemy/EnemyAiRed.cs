using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAiRed : MonoBehaviour
{
    public float launchForce = 10f; // Force applied to the enemy for launching
    private Rigidbody enemyRigidbody;
    private Transform playerTransform;
    private bool hasLaunched = false;
    public float jumpForce = 5f; // Force applied to the enemy for jumping
    private bool hasJumped = false;

    private void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // Adjust the tag as needed

        Jump(); // Call the Jump method
    }

    private void Update()
    {
        // You can implement additional behavior for the enemy here if needed
    }

    private void Jump()
    {
        if (!hasJumped)
        {
            enemyRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            hasJumped = true;
        }
        Invoke("LaunchTowardsPlayer", 3f); // Invoke LaunchTowardsPlayer after 3 seconds
    }

    private void LaunchTowardsPlayer()
    {
        if (!hasLaunched && playerTransform != null)
        {
            Vector3 launchDirection = (playerTransform.position - transform.position).normalized;
            enemyRigidbody.AddForce(launchDirection * launchForce, ForceMode.Impulse);
            hasLaunched = true;
        }
    }
}
