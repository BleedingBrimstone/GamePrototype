using UnityEngine;
using static UnityEngine.ParticleSystem;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; // Префаб пули
    public float spawnInterval = 1f; // Интервал между выстрелами

    public Transform shotPos;

    private void Start()
    {
        InvokeRepeating("Attack", 0f, spawnInterval);
    }
    public void Attack()
    {
        Instantiate(bulletPrefab, shotPos.transform.position, transform.rotation);
    }
}