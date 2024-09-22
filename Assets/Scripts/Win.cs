using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    [SerializeField] GameObject winScreen;
    [SerializeField] Transform canvas;
    [SerializeField] Timer timer;
    [SerializeField] PlayerMovement player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Win" && player.canMove)
        {
            Instantiate(winScreen, canvas);

            canvas.GetComponentInChildren<Scoreboard>().setScore(timer.getScore());
            canvas.GetComponentInChildren<EndScreenText>().time = (timer.getScore());

            player.enabled = false;

            canvas.GetComponentInChildren<Timer>().gameObject.SetActive(false);
        }
    }
}
