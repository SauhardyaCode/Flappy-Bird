using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using UnityEngine.UI;

public class MainGameToSWScript : MonoBehaviour
{
    public Button button;
    private AudioManagerScript audioManager;

    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio Tag").GetComponent<AudioManagerScript>();
    }

    public async void returnToHome()
    {
        button.interactable = false;
        audioManager.PlaySFX(audioManager.buttonClip, false);
        await Task.Delay(500);
        CursorManagerScript.instance.ToPointer();
        SceneManager.LoadScene("StartWindow");
    }
}
