using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject RedPrefab;
    [SerializeField] private GameObject BluePrefab;

    private float initialSpawnInterval = 5f;
    private float minSpawnInterval = 2f;
    private int redEnemyCount = 4;
    private int blueEnemyCount = 1;
    private int redEnemyIncrease = 4;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        float spawnInterval = initialSpawnInterval;
        int totalBlueSpawned = 0;
        int totalRedSpawned = 0;

        while (true)
        {
            SpawnEnemy(BluePrefab, new Vector3(0, 0, 2)); // Example spawn coordinates for Blue
            totalBlueSpawned++;
            if (totalBlueSpawned >= 3)
            {
                totalBlueSpawned = 0;
                totalRedSpawned = 0;
            }

            for (int i = 0; i < blueEnemyCount && totalBlueSpawned < 3; i++)
            {
                SpawnEnemy(BluePrefab, GetRandomSpawnPosition());
                totalBlueSpawned++;
            }

            for (int i = 0; i < redEnemyCount && totalRedSpawned < 12; i++)
            {
                SpawnEnemy(RedPrefab, GetRandomSpawnPosition());
                totalRedSpawned++;
            }

            yield return new WaitForSeconds(spawnInterval);

            // Adjust spawn interval and enemy counts
            spawnInterval = Mathf.Max(spawnInterval - 1f, minSpawnInterval);
            redEnemyCount += redEnemyIncrease;
            blueEnemyCount = redEnemyCount / redEnemyIncrease; // Maintain the 1:4 proportion
        }
    }


    private Vector3 GetRandomSpawnPosition()
    {
        float randomX = Random.Range(-3f, 3f);
        float randomZ = Random.Range(-2.5f, 2.9f);
        return new Vector3(randomX, 1f, randomZ);
    }

    private void SpawnEnemy(GameObject enemyPrefab, Vector3 spawnPosition)
    {
        NavMeshHit hit;
        if (NavMesh.SamplePosition(spawnPosition, out hit, 5.0f, NavMesh.AllAreas))
        {
            Instantiate(enemyPrefab, hit.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Failed to find valid spawn position for enemy.");
        }
    }
}
