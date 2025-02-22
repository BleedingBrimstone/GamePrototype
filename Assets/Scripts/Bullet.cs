using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  m_SpriteRenderer.flipX = flip;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public SpriteRenderer m_SpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 10f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("�oll" + collision.name);
        if (collision.CompareTag("Ground") || collision.CompareTag("Wall") || collision.CompareTag("Coin"))
        {
            Destroy(gameObject);
        }
    }

    public void SetDir(float dir)
    {
        rb.velocity = new Vector2(dir * speed, 0);
    }

    public void FlipBullet(bool flip)
    {
        if (m_SpriteRenderer != null)
        {
            m_SpriteRenderer.flipX = flip;
        }

        else
        {
            Debug.LogError("No");
        }
    }
}
