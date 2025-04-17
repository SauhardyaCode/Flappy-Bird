using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore = 0;
    public Text scoreText;
    public GameObject gameOverScreen;
    public int highScore;

    private void Start()
    {
        updateScore(0);
    }

    public void updateScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        if (playerScore >  highScore)
        {
            PlayerPrefs.SetInt("HighScore", playerScore);
            highScore = playerScore;
        }
    }
}
