using UnityEngine;

public class StartWindowScript : MonoBehaviour
{
    private SceneManagerScript sceneManager;

    void Awake()
    {
        sceneManager = GameObject.FindGameObjectWithTag("Scene Tag").GetComponent<SceneManagerScript>();
    }

    public void startGame()
    {
        Debug.Log("Attempting to change the scene!");
        sceneManager.LoadScene("MainGame");
    }
}
