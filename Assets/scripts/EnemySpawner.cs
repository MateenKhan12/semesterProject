using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // The enemy prefab to spawn
    public Transform spawnPointA; // The first spawn point
    public Transform spawnPointB; // The second spawn point
    public float spawnInterval = 3f; // Time between spawns

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        if (enemyPrefab != null && spawnPointA != null && spawnPointB != null)
        {
            // Choose a random position between two points
            Vector3 randomPosition = new Vector3(
                Random.Range(spawnPointA.position.x, spawnPointB.position.x),
                spawnPointA.position.y,
                Random.Range(spawnPointA.position.z, spawnPointB.position.z)
            );

            // Spawn the enemy
            Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
        }
    }
}
