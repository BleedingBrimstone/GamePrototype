using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    // Healthbar
    public Boss playerHealth;
    public Image hp_total;
    public Image hp_current;

    void Start()
    {
        hp_total.fillAmount = playerHealth.startingHealth / 10;
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        leftEdge = transform.position.x - movementDistance;
        rightEdge = transform.position.x + movementDistance;
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    void Update()
    {
        hp_current.fillAmount = playerHealth.currentHealth / 10;
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

// Sounds
[SerializeField] private AudioClip damage1;

    private Animator anim;
    private bool dead;
    public float startingHealth;
    public float currentHealth { get; private set; }

    [SerializeField] private float flashDuration = 0.2f; // Длительность покраснения
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    public float damage;
    public float movementDistance;
    public float speed;
    private float leftEdge;
    private float rightEdge;
    private bool movingLeft;

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

    public void takeDamage(float _damage)
    {
        AudioManager.instance.PlaySound(damage1);
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        if (currentHealth > 0)
        {
            FlashRed();
        }
        else
        {
            if (!dead)
            {
                Destroy(gameObject, 2f);
            }
        }
    }
    public void addHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Bullet")
        {
            FlashRed();
            currentHealth -= 1;
            if (currentHealth <= 0)
            {
                Destroy(gameObject, 0.2f);
            }
        }

        if (collision.tag == "Player")
        {
            collision.GetComponent<Heart>().takeDamage(damage);
        }
    }
}
