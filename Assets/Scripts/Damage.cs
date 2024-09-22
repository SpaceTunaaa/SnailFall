using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] Transform canvas;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Damaging")
        {
            Instantiate(gameOverScreen, canvas);

            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            GetComponent<PlayerMovement>().disableMovement();

            if (canvas.GetComponentInChildren<Timer>())
            {
                canvas.GetComponentInChildren<Timer>().gameObject.SetActive(false);
            }
        }
    }
}
