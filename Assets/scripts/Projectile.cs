using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    private float direction;

    private void Start()
    {
        Destroy(gameObject, 3f); // Destroy after 3 seconds
    }

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * direction, 0, 0); // Move in the set direction
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Health>()?.TakeDamage(1);
        }

        Destroy(gameObject); // Destroy projectile on collision
    }

    public void SetDirection(float _direction)
    {
        direction = Mathf.Sign(_direction);
        transform.localScale = new Vector3(
            Mathf.Abs(transform.localScale.x) * direction,
            transform.localScale.y,
            transform.localScale.z
        );
    }
}