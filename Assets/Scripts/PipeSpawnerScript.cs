using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 5;
    public float heightOffset = 8;
    private float timer = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnPipe();
            timer = 0;
        }
    }

    void spawnPipe()
    {
        float lowestPoint = pipe.transform.position.y - heightOffset;
        float highestPoint = pipe.transform.position.y + heightOffset;

        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint,highestPoint), 0), transform.rotation);
    }
}
