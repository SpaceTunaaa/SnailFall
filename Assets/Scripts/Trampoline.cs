using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] Vector2 direction = Vector2.up;
    [SerializeField] float magnitude;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            collision.gameObject.GetComponent<PlayerMovement>().AddImpulse(direction.normalized * magnitude);
        }
    }
}
