using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    // Sound
    [SerializeField] private AudioClip trail1;

    public float fireRate = 0.3f;
    public Transform shotPos;
    public GameObject Body;
    public GameObject Bullet;

    private float nextFireTime;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Attack();
        }

    }

    public void Attack()
    {
        AudioManager.instance.PlaySound(trail1);
        GameObject bullet = Instantiate(Bullet, shotPos.transform.position, transform.rotation);
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (Body.transform.localScale.x == -1)
        {
            bulletScript.FlipBullet(true);
        }

        else
        {
            bulletScript.FlipBullet(false);
        }
        
        bulletScript.SetDir(transform.localScale.x);
    }
}
