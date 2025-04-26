using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; // ������ ����
    public float spawnInterval = 1f; // �������� ����� ����������
    public float bulletSpeed = 5f; // �������� ����

    private void Start()
    {
        // ��������� ������������� ����� ������ SpawnBullet
        InvokeRepeating(nameof(SpawnBullet), 0f, spawnInterval);
    }

    private void SpawnBullet()
    {
        // ������� ���� �� ������� ��������
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        // ������ �������� ���� ������
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.right * bulletSpeed;
        }
    }
}