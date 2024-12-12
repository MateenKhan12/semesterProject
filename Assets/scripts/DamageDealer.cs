using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [Header("Damage Settings")]
    [SerializeField] private float damageAmount = 1f; // Amount of damage dealt to the player

    [SerializeField] private bool destroyOnContact = true; // Whether the enemy gets destroyed upon dealing damage

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object is the player
        if (collision.gameObject.CompareTag("player"))
        {
            // Try to apply damage to the player
            Health playerHealth = collision.gameObject.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }

            // Destroy the enemy if specified
            if (destroyOnContact)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collided object is the player
        if (collision.CompareTag("player"))
        {
            // Try to apply damage to the player
            Health playerHealth = collision.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }

            // Destroy the enemy if specified
            if (destroyOnContact)
            {
                Destroy(gameObject);
            }
        }
    }
}