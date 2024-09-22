using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speedometer : MonoBehaviour
{
    [SerializeField] RectTransform needle;
    [SerializeField] Rigidbody2D player;

    private void Update()
    {
        float speed = 54.2f - Mathf.Max(player.velocity.magnitude) / 50 * 190;

        needle.rotation = Quaternion.Euler(new Vector3(0, 0, speed + (-speed + 54.2f) /190 * 2.5f * Mathf.Sin(Time.time * 30 * (-speed + 54.2f) / 190)));
    }
}
