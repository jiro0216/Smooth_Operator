using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemySpawn;
    public int maxEnemies = 3;
    public float minSpawnInterval = 2f;
    public float maxSpawnInterval = 5f;
    public float spawnRadius = 5f;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Check if the maximum number of enemies has been reached
            if (GameObject.FindGameObjectsWithTag("Enemy").Length < maxEnemies)
            {
                // Calculate a random position within the spawn radius
                Vector3 randomPosition = transform.position + Random.insideUnitSphere * spawnRadius;

                // Instantiate the enemy at the random position
                Instantiate(EnemySpawn, randomPosition, Quaternion.identity);
            }

            // Calculate a random spawn interval
            float randomInterval = Random.Range(minSpawnInterval, maxSpawnInterval);

            // Wait for the next spawn
            yield return new WaitForSeconds(randomInterval);
        }
    }
}
