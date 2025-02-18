using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    #region atributos
    public float walkSpeed = 12;
    public float jumpSpeed = 18;
    public bool betterJump = false;
    public float lowJumpMultiplier = 1f;
    public float fallMultiplier = 0.5f;
    public SpriteRenderer spriteRenderer;
    public bool canMove = true;

    [SerializeField]
    private Vector2 knockbackSpeed;

    Rigidbody2D rb;
    Animator animator;

    #endregion

    #region funciones y métodos
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        if (canMove)
        {
            OnWalk();
            OnJump();
        }     

        if (CheckGround.isGrounded == false)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Walk", false);
        }
        else
        {
            animator.SetBool("Jump", false);
            animator.SetBool("Fall", false);
        }

        if(rb.velocity.y < 0)
        {
            animator.SetBool("Fall", true);
        }
        else if(rb.velocity.y > 0)
        {
            animator.SetBool("Fall", false);
        }
    }

    private void OnWalk()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            
            rb.velocity = new Vector2(walkSpeed, rb.velocity.y);
            animator.SetBool("Walk", true);
            spriteRenderer.flipX = false;    
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
           
            rb.velocity = new Vector2(-walkSpeed, rb.velocity.y);
            animator.SetBool("Walk", true);
            spriteRenderer.flipX = true;
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetBool("Walk", false);
        }

    }

    private void OnJump()
    {
        if (Input.GetKey("w") || Input.GetKey("up") || Input.GetKey("space"))
        {
            if (CheckGround.isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            }

        }

        if (betterJump)
        {
            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
            }
            else if (rb.velocity.y > 0)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
            }
        }
    }

    public void OnKnockback(Vector2 playerIsHit)
    {
        rb.velocity = new Vector2(-knockbackSpeed.x * playerIsHit.x, knockbackSpeed.y);
    }


    #endregion
}
