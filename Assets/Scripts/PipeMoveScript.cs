using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed = 5;
    private float destroyPipeZone;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        destroyPipeZone = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x - 5;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        if (transform.position.x < destroyPipeZone)
        {
            Debug.Log("Pipe Deleted!");
            Destroy(gameObject);
        }
    }
}
