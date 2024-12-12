using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Movement Settings")]
    public Transform player; // Reference to the player’s Transform

    public float moveSpeed = 2f; // Speed of movement towards the player

    [Header("Score Settings")]
    public int scoreValue = 10; // Points awarded upon destruction

    [Header("Explosion Sound")]
    [SerializeField] private AudioClip explosionSound; // The sound effect for explosion
    private AudioSource audioSource; // Reference to the AudioSource component

    private void Start()
    {
        // Optionally find the player dynamically
        if (player == null && GameObject.FindGameObjectWithTag("player") != null)
        {
            player = GameObject.FindGameObjectWithTag("player").transform;
        }

        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>(); // Add AudioSource if it's missing
        }
    }

    private void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }

    private void OnDestroy()
    {
        // Play explosion sound when the enemy is destroyed
        if (explosionSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(explosionSound); // Play sound effect
        }

        // Add score when the enemy is destroyed
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.AddScore(scoreValue);
        }
    }
}
