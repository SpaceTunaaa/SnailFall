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
    public bool canMove = true;

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && canMove)
        {
            if (groundedCollider.IsTouchingLayers())
            {
                AddImpulse(Vector2.up * jumpForce);
            }
        }
    }

    private void FixedUpdate()
    {
        if ( !circleCollider.IsTouchingLayers() &&
            (Mathf.Sign(rb.velocity.x) != Mathf.Sign(Input.GetAxis("Horizontal")) || Mathf.Abs(rb.velocity.x) < maxHorizontalSpeed
            && canMove)) { 
            rb.AddForce(new Vector2(horizontalAcceleration * Input.GetAxis("Horizontal"), 0));
        }
        //else
        //{
        //    Vector2 targetVelocity = new Vector2(Mathf.Sign(Input.GetAxis("Horizontal")) * maxHorizontalSpeed, rb.velocity.y);
        //    Vector2 deltaVelocity = targetVelocity - rb.velocity;
        //    rb.AddForce(deltaVelocity);
        //}

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
    }
}
