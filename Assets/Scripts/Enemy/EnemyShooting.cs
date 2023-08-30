using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public static bool playerTeleported = false;
    public Transform player; // Reference to the player's transform
    public GameObject projectilePrefab; // Prefab of the projectile to be shot
    public GameObject projectilePoint;
    public float minShootInterval = 1f; // Minimum interval between shots in seconds
    public float maxShootInterval = 3f; // Maximum interval between shots in seconds
    public float shootForce = 1f; // Force applied to the projectile when shooting
    public float rocketSpeed = 10f; // Adjustable speed of the rocket

    private bool shouldChasePlayer = true; // Flag to control chasing behavior
    private float timeSinceLastShot = 0f;
    private float nextShootTime = 0f;

    private Coroutine reEnableChasingCoroutine;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform; // Find the player using tag
        CalculateNextShootTime();
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (Time.time >= nextShootTime && distanceToPlayer < 10f)
        {
            if (shouldChasePlayer)
            {
                Debug.Log("enemy missile");

                GameObject rocket = Instantiate(projectilePrefab, projectilePoint.transform.position, Quaternion.identity);
                rocket.transform.LookAt(player.transform);

                StartCoroutine(Shoot(rocket));
            }
            else
            {
                // Regular missile logic without chasing
                GameObject rocket = Instantiate(projectilePrefab, projectilePoint.transform.position, Quaternion.identity);
                rocket.GetComponent<Rigidbody>().velocity = transform.forward * rocketSpeed;
            }

            CalculateNextShootTime();
        }
    }

    private void CalculateNextShootTime()
    {
        nextShootTime = Time.time + Random.Range(minShootInterval, maxShootInterval);
    }

    public IEnumerator Shoot(GameObject rocket)
    {
        Rigidbody rocketRigidbody = rocket.GetComponent<Rigidbody>(); // Cache the rigidbody reference

        while (shouldChasePlayer && rocketRigidbody != null && Vector3.Distance(player.transform.position, rocket.transform.position) > 0.3f)
        {
            Vector3 shootDirection = (player.transform.position - rocket.transform.position).normalized;
            rocketRigidbody.velocity = shootDirection * rocketSpeed;
            yield return null;
        }

        if (shouldChasePlayer && rocketRigidbody != null)
        {
            Destroy(rocket);
            PlayerUltimate.MinusPower(25);
        }
    }


    // Update the chasing behavior flag when right mouse button is pressed
    private void LateUpdate()
    {
        if (PlayerTeleportation.canTeleport == false) 
        {
            shouldChasePlayer = false;
            if (reEnableChasingCoroutine != null)
            {
                StopCoroutine(reEnableChasingCoroutine);
            }
            reEnableChasingCoroutine = StartCoroutine(ReEnableChasingAfterDelay());
        }
    }

    private IEnumerator ReEnableChasingAfterDelay()
    {
        yield return new WaitForSeconds(3f); // Wait for 3 seconds
        shouldChasePlayer = true;
    }

}
