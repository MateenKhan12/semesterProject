using UnityEngine;

public class EnhancedSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject[] enemyPrefabs;  // Array of enemy prefabs

    public float initialSpawnInterval = 2f; // Initial time between spawns
    public float difficultyIncreaseRate = 0.95f; // Multiplier for spawn interval reduction
    public int maxEnemyCount = 10;    // Maximum active enemies

    [Header("Spawn Area")]
    public Vector2 spawnAreaMin;      // Bottom-left corner of spawn area

    public Vector2 spawnAreaMax;      // Top-right corner of spawn area

    private float spawnTimer;         // Timer for spawning enemies
    private int currentEnemyCount;    // Current active enemy count
    private float currentSpawnInterval; // Current interval between spawns

    private void Start()
    {
        currentSpawnInterval = initialSpawnInterval;
        spawnTimer = currentSpawnInterval;
    }

    private void Update()
    {
        HandleSpawning();
    }

    private void HandleSpawning()
    {
        if (currentEnemyCount >= maxEnemyCount) return;

        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0f)
        {
            SpawnEnemy();
            currentSpawnInterval *= difficultyIncreaseRate; // Increase difficulty
            spawnTimer = currentSpawnInterval; // Reset spawn timer
        }
    }

    private void SpawnEnemy()
    {
        if (enemyPrefabs.Length > 0)
        {
            // Randomly select an enemy type
            GameObject enemyToSpawn = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

            // Random position within the specified range
            float randomX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
            float randomY = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
            Vector2 spawnPosition = new Vector2(randomX, randomY);

            // Spawn the enemy and increment the count
            Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity);
            currentEnemyCount++;
        }
    }

    public void EnemyDestroyed()
    {
        // Call this method from the enemy when it is destroyed
        currentEnemyCount--;
    }

    private void OnDrawGizmosSelected()
    {
        // Visualize the spawn area in the Scene view
        Gizmos.color = Color.red;
        Vector2 center = (spawnAreaMin + spawnAreaMax) / 2;
        Vector2 size = spawnAreaMax - spawnAreaMin;
        Gizmos.DrawWireCube(center, size);
    }
}