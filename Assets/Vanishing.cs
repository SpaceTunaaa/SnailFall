using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vanishing : MonoBehaviour
{
    [SerializeField] SpriteRenderer spr;

    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            StartCoroutine(vanish());
        }
    }

    IEnumerator vanish()
    {
        for (float i = 0; i < 1; i += Time.deltaTime)
        {
           yield return new WaitForSeconds(0);

            spr.color = new Color(spr.color.r, spr.color.g, spr.color.b, (1 - i));
        }

        Destroy(gameObject);
    }
}
