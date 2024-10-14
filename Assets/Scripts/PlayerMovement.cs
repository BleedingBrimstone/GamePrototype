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

    public LayerMask groundLayer;
    public LayerMask wallLayer;
    private float wallJumpCooldown;
    private CapsuleCollider2D capsuleCollider;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontal*walk_speed, body.velocity.y);
        if (Input.GetKey(KeyCode.Space) && IsGrounded())
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
        anim.SetBool("ground", IsGrounded());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "Ground")
        //{
        //    grounded = true;
        //}
    }
    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jump_speed);
        anim.SetTrigger("jump");
    }
    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(capsuleCollider.bounds.center, capsuleCollider.bounds.size,0,Vector2.down,0.1f,groundLayer);
        return raycastHit.collider != null;
    }
    private bool OnWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(capsuleCollider.bounds.center, capsuleCollider.bounds.size, 0, new Vector2(transform.localScale.x,0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }
}
