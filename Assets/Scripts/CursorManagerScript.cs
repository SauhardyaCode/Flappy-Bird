using UnityEngine;

public class CursorManagerScript : MonoBehaviour
{
    public Texture2D pointer;
    public Texture2D hand;

    private Vector2 pointerHotspot;
    private Vector2 handHotspot;

    public static CursorManagerScript instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        pointerHotspot = new Vector2 (0, 0);
        handHotspot = new Vector2 (0, 0);
        ToPointer();
    }

    public void ToPointer()
    {
        Cursor.SetCursor(pointer, pointerHotspot, CursorMode.Auto);
    }

    public void ToHand()
    {
        Cursor.SetCursor(hand, handHotspot, CursorMode.Auto);
    }

}
