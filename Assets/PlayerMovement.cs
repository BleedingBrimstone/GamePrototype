using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float walk_speed = 10f;
    public float jump_speed = 5f;
    public bool grounded;

    private Rigidbody2D body;
    private Animator anim;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontal*walk_speed, body.velocity.y);
        if (Input.GetKey(KeyCode.Space) && grounded == true)
        {
            Jump();
        }
        // Character flip
        if (horizontal>0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontal<-0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        // Anim
        anim.SetBool("move", horizontal != 0);
        anim.SetBool("ground", grounded);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jump_speed);
        grounded = false;
    }
}
