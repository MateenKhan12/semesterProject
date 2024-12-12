using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private float length, startPos;
    public float scrollSpeed = 2f; // Speed of scrolling

    private void Start()
    {
        // Get the initial position and the length of the background
        startPos = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.y; // Use height for vertical scrolling
    }

    private void FixedUpdate()
    {
        // Move the background vertically (scroll down)
        transform.position += Vector3.down * scrollSpeed * Time.deltaTime;

        // Reset the position for seamless looping
        if (transform.position.y <= startPos - length)
        {
            transform.position = new Vector3(transform.position.x, startPos, transform.position.z);
        }
    }
}
