using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPooler : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab; // Bullet prefab to pool
    [SerializeField] private int initialPoolSize = 10; // Initial number of bullets in the pool
    [SerializeField] private int poolExpansionSize = 5; // Number of bullets to add when pool is empty

    private Queue<GameObject> bulletPool;

    private void Start()
    {
        bulletPool = new Queue<GameObject>();

        // Create and store bullets in the pool
        for (int i = 0; i < initialPoolSize; i++)
        {
            CreateNewBullet();
        }
    }

    private void CreateNewBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.SetActive(false);
        bulletPool.Enqueue(bullet);
    }

    public GameObject GetBullet()
    {
        // If the pool is empty, expand it
        if (bulletPool.Count == 0)
        {
            ExpandPool();
        }

        GameObject bullet = bulletPool.Dequeue();
        bullet.SetActive(true);
        return bullet;
    }

    private void ExpandPool()
    {
        Debug.Log("Expanding bullet pool...");
        for (int i = 0; i < poolExpansionSize; i++)
        {
            CreateNewBullet();
        }
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        bulletPool.Enqueue(bullet); // Return the bullet to the pool
    }
}