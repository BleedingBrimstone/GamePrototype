using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; // Префаб пули
    public float spawnInterval = 1f; // Интервал между выстрелами
    public float bulletSpeed = 5f; // Скорость пули

    private void Start()
    {
        // Запускаем повторяющийся вызов метода SpawnBullet
        InvokeRepeating(nameof(SpawnBullet), 0f, spawnInterval);
    }

    private void SpawnBullet()
    {
        // Создаем пулю на позиции пустышки
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        // Задаем скорость пули вправо
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.right * bulletSpeed;
        }
    }
}