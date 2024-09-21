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
    public bool canMove = true;
    bool playerNotFalling;
    float timeNotFalling;

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

        if (rb.velocity.y > -50)
        {
            rb.AddForce(new Vector2(0, -50 - rb.velocity.y));
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
