using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class StartWindowScript : MonoBehaviour
{
    public Button button;
    private SWAudioManagerScript audioManager;

    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio Tag").GetComponent<SWAudioManagerScript>();
    }

    public void startGame()
    {
        button.interactable = false;
        StartCoroutine(StartGameRoutine());
    }

    private IEnumerator StartGameRoutine()
    {
        audioManager.musicSource.Stop();
        audioManager.PlaySFX(audioManager.buttonClip, false);
        yield return new WaitForSeconds(0.5f);
        CursorManagerScript.instance.ToPointer();
        SceneManager.LoadScene("MainGame");
    }

    public void exitGame()
    {
        button.interactable = false;
        StartCoroutine(ExitGameRoutine());
    }

    private IEnumerator ExitGameRoutine()
    {
        audioManager.musicSource.Stop();
        audioManager.PlaySFX(audioManager.buttonClip, false);
        yield return new WaitForSeconds(0.5f);
        CursorManagerScript.instance.ToPointer();
        Application.Quit();
    }

}
