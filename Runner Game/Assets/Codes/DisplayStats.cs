using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class DisplayStats : MonoBehaviour
{
    public TMP_Text lastScore;
    public TMP_Text highestScore;

    private void OnEnable()
    {
        if (PlayerPrefs.HasKey("score"))
        {
            lastScore.text = "Last Score: " + PlayerPrefs.GetInt("score");
        }
        else
        {
            lastScore.text = "Last Score: 0";
        }

        if (PlayerPrefs.HasKey("highscore"))
        {
            highestScore.text = "Highest Score: " + PlayerPrefs.GetInt("highestScore");
        }
        else
        {
            highestScore.text = "Highest Score: 0";
        }
    }
}
