using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI leaderboard;
    [SerializeField] TMP_InputField inputField;
    dreamloLeaderBoard dl;
    List<dreamloLeaderBoard.Score> scores = new List<dreamloLeaderBoard.Score>();
    float time;

    void Start()
    {
        // get the reference here
        this.dl = dreamloLeaderBoard.GetSceneDreamloLeaderboard();
    }

    private void Update()
    {

        scores = dl.ToListHighToLow();

        if (scores.Count != 0)
        {
            string text = "";

            for (int i = 0; i < scores.Count; i++)
            {
                text += scores[i].playerName + " : " + formatTime(scores[i].score/100f) + "\n";
                
            }
            leaderboard.text = text;
        }
    }

    public void setScore(float time)
    {
        this.time = time;
    }

    public void addTime()
    {
        //textMeshProUGUI.text = score;

        string username = inputField.text;

        dl.AddScore(username.ToUpper(), (int)(time*100));
    }

    public static string formatTime(float time)
    {
        string @decimal = time.ToString();
        int decimalPlace = @decimal.IndexOf(".");
        if (decimalPlace + 2 < @decimal.Length && decimalPlace >= 0)
        {
            @decimal = @decimal.Substring(decimalPlace, 3);
        }
        else if (decimalPlace >= 0)
        {
            @decimal = @decimal.Substring(decimalPlace);

            while (@decimal.Length < 3)
            {
                @decimal += "0";
            }
        }
        else
        {
            @decimal = ".00";
        }
        int minutes = (int)time / 60;
        int seconds = (int)time % 60;
        
        return (minutes != 0 ? minutes.ToString() + ":" : "") + (seconds.ToString().Length == 1 && minutes > 0 ? "0" : "") + seconds.ToString() + @decimal;
    }
}
