using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 2f; // Enemy speed
    private Vector2 direction = Vector2.down; // Default direction (down)

    private void Update()
    {
        // Move the enemy in the set direction
        transform.Translate(direction * speed * Time.deltaTime);

        // Destroy the enemy if it goes off-screen
        Vector2 minScreenBounds = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        if (transform.position.y < minScreenBounds.y - 1f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Handle collision with the player
        if (collision.CompareTag("Player"))
        {
            // Damage the player or end the game
            Debug.Log("Player hit!");
            Destroy(gameObject);
        }

        // Destroy the enemy if hit by a projectile
        if (collision.CompareTag("Projectile"))
        {
            Destroy(gameObject);
        }
    }
}
