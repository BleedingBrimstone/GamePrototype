using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public float bulletSpeed = 5f;
    public float damage = 2f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall") || collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }

        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Heart>().takeDamage(damage);
            Destroy(gameObject);
        }
    }

}