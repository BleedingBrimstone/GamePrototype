using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class damage_enemy : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
    if (collision.tag == "Player")
        {
            collision.GetComponent<Heart>().takeDamage(damage);
        }
    }
}
