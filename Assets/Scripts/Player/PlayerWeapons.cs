using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    public GameObject spherePrefab; // Prefab of the sphere to be shot
    public float shootForce = 10f; // Force applied to the sphere when shooting
    public float spawnDistance = 1.5f; // Distance from the camera to spawn the sphere
    public float minTimeBetweenShots = 0.5f; // Minimum time between shots in seconds
    private float nextShootTime = 0f; // Time when the next shot can be fired

    void Update()
    {
        // Check for mouse button press and ensure enough time has passed
        if (Input.GetButtonDown("Fire1") && Time.time >= nextShootTime)
        {
            Shoot();
            nextShootTime = Time.time + minTimeBetweenShots; // Update the next shoot time
        }
    }

    public void Shoot()
    {
        // Get the FPS camera's transform
        Transform cameraTransform = Camera.main.transform;

        // Calculate the position where the sphere should be spawned
        Vector3 spawnPosition = cameraTransform.position + cameraTransform.forward * spawnDistance;

        // Create a sphere at the spawn position
        GameObject newSphere = Instantiate(spherePrefab, spawnPosition, Quaternion.identity);

        // Get the sphere's rigidbody
        Rigidbody sphereRigidbody = newSphere.GetComponent<Rigidbody>();

        // Apply forward force to the sphere to simulate shooting
        sphereRigidbody.AddForce(cameraTransform.forward * shootForce, ForceMode.Impulse);
    }
}
