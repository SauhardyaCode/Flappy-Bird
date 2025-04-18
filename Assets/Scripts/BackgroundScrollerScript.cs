using UnityEngine;
using UnityEngine.UI;

public class BackgroundScrollerScript : MonoBehaviour
{
    public RawImage rock1, rock2, rock3, cloud1, cloud2;
    public float speed_rock1, speed_rock2, speed_rock3, speed_cloud1, speed_cloud2;

    // Update is called once per frame
    void Update()
    {
        updateAsset(rock1, speed_rock1);
        updateAsset(rock2, speed_rock2);
        updateAsset(rock3, speed_rock3);
        updateAsset(cloud1, speed_cloud1);
        updateAsset(cloud2, speed_cloud2);
    }

    void updateAsset(RawImage image, float x)
    {
        image.uvRect = new Rect((image.uvRect.position + new Vector2(x, 0) * Time.deltaTime), image.uvRect.size);
    }
}
