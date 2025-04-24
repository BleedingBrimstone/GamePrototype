using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hp;
    public float damage;

    public float movementDistance;
    public float speed;
    private float leftEdge;
    private float rightEdge;
    private bool movingLeft;

    [SerializeField] private float flashDuration = 0.2f; // Длительность покраснения
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    void Start()
    {
        leftEdge = transform.position.x - movementDistance;
        rightEdge = transform.position.x + movementDistance;
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    void Update()
    {
        if (movingLeft)
        {
            if (transform.position.x > leftEdge)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                movingLeft = false;
            }
        }
        else
        {
            if (transform.position.x < rightEdge)
            {
                transform.localScale = new Vector3(1, 1, 1);
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                movingLeft = true;
            }
        }
    }
    private IEnumerator FlashRedCoroutine()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = originalColor;
    }

    public void FlashRed()
    {
        StartCoroutine(FlashRedCoroutine());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Bullet")
        {
            FlashRed();
            hp -= 1;
            if (hp <= 0)
            {
                Destroy(gameObject);
            }
        }

        if (collision.tag == "Player")
        {
            collision.GetComponent<Heart>().takeDamage(damage);
        }
    }
}