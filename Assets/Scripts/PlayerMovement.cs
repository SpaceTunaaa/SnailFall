using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float horizontalAcceleration;
    [SerializeField] float maxHorizontalSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] Collider2D groundedCollider;
    [SerializeField] Collider2D circleCollider;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;
    public bool canMove = true;
    bool playerNotFalling;
    float timeNotFalling;
    public float speedModifier;

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && canMove)
        {
            if (groundedCollider.IsTouchingLayers())
            {
                AddImpulse(Vector2.up * jumpForce);
            }
        }

        playerNotFalling = rb.velocity.sqrMagnitude < 0.1f;

        if (playerNotFalling )
        {
            timeNotFalling += Time.deltaTime;
        }
        else
        {
            timeNotFalling = 0;
        }

        if (timeNotFalling > 3)
        {
            AddImpulse(Vector2.up * jumpForce);
        }

        if (timeNotFalling > 5)
        {
            Debug.LogError("Player stayed still for too long");
        }

        if (rb.velocity.y < 0 && canMove)
        {
            animator.SetBool("Falling", true);
        }else if (canMove)
        {
            animator.SetBool("Falling", false);
        }

        if((Input.GetAxis("Horizontal")) < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    private void FixedUpdate()
    {
        if ( !circleCollider.IsTouchingLayers() &&
            (Mathf.Sign(rb.velocity.x) != Mathf.Sign(Input.GetAxis("Horizontal")) || Mathf.Abs(rb.velocity.x) < maxHorizontalSpeed
            && canMove)) { 
            rb.AddForce(new Vector2(horizontalAcceleration * Input.GetAxis("Horizontal"), 0));
        }
        else if(circleCollider.IsTouchingLayers() && canMove && playerNotFalling)
        {
            Collider2D[] collider2Ds = new Collider2D[0];

            circleCollider.GetContacts(collider2Ds);

            float sum = 0;

            for (int i = 0; i < collider2Ds.Length; i++)
            {
                sum += collider2Ds[i].transform.position.x - transform.position.x;
            }

            rb.AddForce(new Vector2(horizontalAcceleration * (sum > 0 ? -1 : 1), -5));
        }

        if (rb.velocity.y > -40)
        {
            rb.AddForce(new Vector2(0, -40 - rb.velocity.y));
        }

        if(speedModifier != 0 && 
            !(speedModifier > 0 && rb.velocity.magnitude > 100) && 
            !(speedModifier < 0 && rb.velocity.magnitude < 3))
        {
            rb.AddForce(rb.velocity.normalized * speedModifier, ForceMode2D.Impulse);
        }
    }

    public void AddImpulse(Vector2 impulse)
    {
        rb.AddForce(impulse, ForceMode2D.Impulse);
    }

    public void disableMovement()
    {
        canMove = false;

        animator.Play("Death");
    }
}
