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

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (groundedCollider.IsTouchingLayers())
            {
                AddImpulse(Vector2.up * jumpForce);
            }
        }
    }

    private void FixedUpdate()
    {
        if (Mathf.Sign(rb.velocity.x) != Mathf.Sign(Input.GetAxis("Horizontal")) || Mathf.Abs(rb.velocity.x) < maxHorizontalSpeed ) { 
            rb.AddForce(new Vector2(horizontalAcceleration * Input.GetAxis("Horizontal"), 0));
        }
        else
        {
            rb.velocity = new Vector2(Mathf.Sign(Input.GetAxis("Horizontal")) * maxHorizontalSpeed, rb.velocity.y);
        }
    }

    public void AddImpulse(Vector2 impulse)
    {
        rb.AddForce(impulse, ForceMode2D.Impulse);
    }
}
