using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  m_SpriteRenderer.flipX = flip;

public class Bullet : MonoBehaviour
{
    private Animator anim;
    public float speed;
    public Rigidbody2D rb;
    public SpriteRenderer m_SpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
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
        anim.SetTrigger("Explosion");
        Debug.Log("Ñoll" + collision.name);
        StartCoroutine(PauseAndDoSomething());
        if (collision.CompareTag("Ground") || collision.CompareTag("Wall") || collision.CompareTag("Coin") || collision.CompareTag("Enemy"))
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
    private IEnumerator PauseAndDoSomething()
    {
        yield return new WaitForSeconds(1f);
    }
}
