using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{

    // Sound
    [SerializeField] private AudioClip heal1;

    public float add;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            AudioManager.instance.PlaySound(heal1);
            collision.GetComponent<Heart>().addHealth(add);
            Destroy(gameObject);
        }
    }
}
