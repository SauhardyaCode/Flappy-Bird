using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public int highScore;

    public Button button;
    private AudioManagerScript audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio Tag").GetComponent<AudioManagerScript>();
    }

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

    public async void restartGame()
    {
        button.interactable = false;
        audioManager.PlaySFX(audioManager.buttonClip, false);
        await Task.Delay(500);
        CursorManagerScript.instance.ToPointer();
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
