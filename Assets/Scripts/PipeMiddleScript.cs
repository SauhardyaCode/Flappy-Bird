using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    private LogicScript logicManager;
    private AudioManagerScript audioManager;
    private BirdScript birdObject;

    void Awake()
    {
        logicManager = GameObject.FindGameObjectWithTag("Logic Tag").GetComponent<LogicScript>();
        audioManager = GameObject.FindGameObjectWithTag("Audio Tag").GetComponent<AudioManagerScript>();
        birdObject = GameObject.FindGameObjectWithTag("Bird Tag").GetComponent<BirdScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (birdObject.birdIsAlive && collision.gameObject.layer == 7)
        {
            logicManager.updateScore(1);
            audioManager.PlaySFX(audioManager.pointClip, false);
        }
    }
}
