using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreLoad : MonoBehaviour {
    public Text highScore;
    public int score;
    public int highScoreInt;
	// Use this for initialization
	void Update () {
        GetComponent<Text>().text = PlayerPrefs.GetInt("currentScore").ToString();
        score = PlayerPrefs.GetInt("currentScore");
        highScoreInt = PlayerPrefs.GetInt("highScore");

        if (score > highScoreInt)
        {
            PlayerPrefs.SetInt("highScore", score);
            PlayerPrefs.Save();

        }
        highScoreInt = PlayerPrefs.GetInt("highScore");
        highScore.text = highScoreInt.ToString();
        PlayerPrefs.Save();
	}
}
