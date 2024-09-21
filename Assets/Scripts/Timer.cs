using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI tmp;
    private float time;

    private void Update()
    {
        time += Time.deltaTime;
        tmp.text = Scoreboard.formatTime(time);
    }

    public float getScore()
    {
        return time;
    }
}
