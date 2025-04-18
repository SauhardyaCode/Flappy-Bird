using UnityEngine;
using System.Collections;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D birdBody;

    private LogicScript logicManager;
    private AudioManagerScript audioManager;
    private ScoreHighScoreUpdaterScript scoreUpdater;
    public Animator animator;

    public float flapStrength;
    public float skyPos;
    public float groundPos;
    public float boomGravity;

    public bool birdIsAlive = true;
    private bool birdHasFell = false;
    
    void Awake()
    {
        logicManager = GameObject.FindGameObjectWithTag("Logic Tag").GetComponent<LogicScript>();
        audioManager = GameObject.FindGameObjectWithTag("Audio Tag").GetComponent<AudioManagerScript>();
        scoreUpdater = GameObject.FindGameObjectWithTag("Score Tag").GetComponent<ScoreHighScoreUpdaterScript>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isDead", !birdIsAlive);
        if (birdIsAlive)
        {
            CursorManagerScript.instance.ToHand();
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                birdBody.linearVelocityY = flapStrength;
                animator.SetBool("hasFlapped", true);
                audioManager.PlaySFX(audioManager.flapClip);
            }
            if (transform.position.y < groundPos || transform.position.y > skyPos)
            {
                collided();
            }
        }
        else
        {
            if (transform.position.y < groundPos)
            {
                gameOver();
            }
        }
    }

    public void switchAnimationToFalling()
    {
        animator.SetBool("hasFlapped", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            collided();
            collision.gameObject.layer = 0;
        }
    }

    private void collided()
    {
        birdIsAlive = false;
        birdBody.gravityScale = boomGravity;
        audioManager.musicSource.Stop();
        audioManager.PlaySFX(audioManager.crashClip);
    }

    private void gameOver()
    {
        if (!birdHasFell)
        {
            birdHasFell = true;
            CursorManagerScript.instance.ToPointer();
            StartCoroutine(GameOverSequence());
        }
    }

    private IEnumerator GameOverSequence()
    {
        logicManager.gameOver();
        scoreUpdater.updateScoreTextFields(logicManager.playerScore, logicManager.highScore);

        yield return new WaitForSeconds(0.5f);
        audioManager.PlaySFX(audioManager.gameOver1, false);
        yield return new WaitForSeconds(1.5f);
        audioManager.PlaySFX(audioManager.gameOver2, false);
    }
}
