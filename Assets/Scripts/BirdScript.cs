using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D birdBody;

    private LogicScript logicManager;
    private AudioManagerScript audioManager;
    private ScoreHighScoreUpdaterScript scoreUpdater;

    public float flapStrength = 12;
    public float skyPos = 20;
    public float groundPos = -20;
    public float boomGravity = 20;

    public bool birdIsAlive = true;
    
    void Awake()
    {
        logicManager = GameObject.FindGameObjectWithTag("Logic Tag").GetComponent<LogicScript>();
        audioManager = GameObject.FindGameObjectWithTag("Audio Tag").GetComponent<AudioManagerScript>();
        scoreUpdater = GameObject.FindGameObjectWithTag("Score Tag").GetComponent<ScoreHighScoreUpdaterScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (birdIsAlive)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                birdBody.linearVelocityY = flapStrength;
            }
            if (transform.position.y < groundPos || transform.position.y > skyPos)
            {
                gameOver();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            gameOver();
            collision.gameObject.layer = 0;
        }
    }

    private void gameOver()
    {
        logicManager.gameOver();
        birdIsAlive = false;
        birdBody.gravityScale = boomGravity;
        audioManager.musicSource.Stop();
        audioManager.PlaySFX(audioManager.crashClip);
        scoreUpdater.updateScoreTextFields(logicManager.playerScore, logicManager.highScore);
    }
}
