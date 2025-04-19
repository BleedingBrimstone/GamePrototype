using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    
    // Sounds
    [SerializeField] private AudioClip coin1;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            AudioManager.instance.PlaySound(coin1);
            Coincount.coin += 1;
            Destroy(gameObject);
        }
    }
}
