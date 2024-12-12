using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Speed of the player movement
    private Vector2 minBounds; // Minimum X and Y positions (calculated from the camera)
    private Vector2 maxBounds; // Maximum X and Y positions (calculated from the camera)

    private Vector3 targetPosition;

    private void Start()
    {
        // Calculate the screen bounds based on the camera size and player size
        Camera cam = Camera.main;
        float halfPlayerWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
        float halfPlayerHeight = GetComponent<SpriteRenderer>().bounds.extents.y;

        minBounds = cam.ViewportToWorldPoint(new Vector3(0, 0, cam.nearClipPlane)) + new Vector3(halfPlayerWidth, halfPlayerHeight, 0);
        maxBounds = cam.ViewportToWorldPoint(new Vector3(1, 1, cam.nearClipPlane)) - new Vector3(halfPlayerWidth, halfPlayerHeight, 0);
    }

    private void Update()
    {
        // Get the mouse position in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Clamp the player's position within the camera bounds
        targetPosition = new Vector3(
            Mathf.Clamp(mousePosition.x, minBounds.x, maxBounds.x),
            Mathf.Clamp(mousePosition.y, minBounds.y, maxBounds.y),
            transform.position.z // Keep the original Z position
        );

        // Smoothly move the player toward the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
    }
}