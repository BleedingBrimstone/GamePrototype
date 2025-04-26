using UnityEngine;

public class TurretBullet : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall") || collision.CompareTag("Ground") || collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}