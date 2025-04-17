using UnityEngine;
using UnityEngine.UI;

public class HighScoreScript : MonoBehaviour
{
    public Text highScoreText;
    public int highScore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore.ToString();
    }
}
