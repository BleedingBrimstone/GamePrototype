using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hp;
    public float damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
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