using UnityEngine;
using UnityEngine.UI;

public class ScoreHighScoreUpdaterScript : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void updateScoreTextFields(int playerScore, int highScore)
    {
        scoreText.text = "Score: " + playerScore.ToString();
        highScoreText.text = "High Score: " + highScore.ToString();
    }
}
