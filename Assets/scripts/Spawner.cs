using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;      // The enemy prefab to spawn
    public float spawnInterval = 2f;   // Time between each spawn
    public Vector2 spawnAreaMin;       // Minimum x and y coordinates for spawning
    public Vector2 spawnAreaMax;       // Maximum x and y coordinates for spawning

    private float spawnTimer;          // Timer to control spawn intervals

    private void Start()
    {
        spawnTimer = spawnInterval;    // Initialize the spawn timer
    }

    private void Update()
    {
        HandleSpawning();
    }

    private void HandleSpawning()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0f)
        {
            SpawnEnemy();
            spawnTimer = spawnInterval; // Reset the timer
        }
    }

    private void SpawnEnemy()
    {
        if (enemyPrefab != null)
        {
            // Random position within the specified range
            float randomX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
            float randomY = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
            Vector2 spawnPosition = new Vector2(randomX, randomY);

            // Spawn the enemy at the calculated position
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Visualize the spawn area in the Scene view
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube((spawnAreaMin + spawnAreaMax) / 2, spawnAreaMax - spawnAreaMin);
    }
}