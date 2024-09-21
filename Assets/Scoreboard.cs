using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshProUGUI;

    public void setScore(string score)
    {
        textMeshProUGUI.text = score;
    }
}
