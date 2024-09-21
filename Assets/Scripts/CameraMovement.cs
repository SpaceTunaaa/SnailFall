using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Transform background;
    Vector2 previousPos;
    void Update()
    {
        transform.position = new Vector3(0, player.transform.position.y -6, -10);

        Vector2 deltaPos = (Vector2)transform.position - previousPos;
        background.transform.position -= (Vector3)deltaPos / 2;
        previousPos = transform.position;

        if(background.transform.position.y - transform.position.y > 80)
        {
            background.transform.position -= new Vector3(0, 80);
        }
    }
}
