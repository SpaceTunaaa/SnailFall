using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScreenText : MonoBehaviour
{
    [SerializeField] List<string> textList = new List<string>();
    [SerializeField] List<string> tooFastList = new List<string>();
    [SerializeField] TextMeshProUGUI textMeshPro;
    [SerializeField] TextMeshProUGUI yourScore;
    [SerializeField] float tooFastTime;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro.text = textList[Random.Range(0, textList.Count)];

        if (time < tooFastTime)
        {
            textMeshPro.text = tooFastList[Random.Range(0, tooFastList.Count)];
        }

        yourScore.text = "You got to: " + Scoreboard.formatTime(time);
    }
}
