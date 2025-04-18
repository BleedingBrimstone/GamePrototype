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
    public float horizontal;

    private Vector3 respawnPoint;
    public GameObject fallDetector;
    private BoxCollider2D boxCollider;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        respawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        
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

        // Jump
        if (wallJumpCooldown < 0.2f)
        {
            if (Input.GetKey(KeyCode.Space) && IsGrounded())
            {
                Jump();
            }
            body.velocity = new Vector2(horizontal * walk_speed, body.velocity.y);

            if (OnWall() && !IsGrounded())
            {
                body.gravityScale = 0;
                body.velocity = Vector2.zero;
            }
            else
            {
                body.gravityScale = 1;
            }
        }
        else
        {
            wallJumpCooldown += Time.deltaTime;
        }
        fallDetector.transform.position = new Vector2(transform.position.x, transform.position.y);
    }
    private void Jump()
    {
        if (IsGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jump_speed);
            anim.SetTrigger("jump");
        } else if (OnWall() && !IsGrounded())
        {
            wallJumpCooldown = 0;
            body.velocity = new Vector2(-MathF.Sign(transform.localScale.x) * 3, 6);
        }
        
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
    public bool CanAttack()
    {
        return horizontal == 0 && IsGrounded() && !OnWall();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DeadZone")
        {
            transform.position = respawnPoint;
        } else if (collision.tag == "Checkpoint")
        {
            respawnPoint = transform.position;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            transform.SetParent(collision.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            transform.SetParent(null);
        }
    }
}
