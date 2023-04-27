using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct ColliderData
{
    Vector2 center;
    Vector2 size;
}

public class GenerateMap : MonoBehaviour
{
    public Vector2 platformSpawnSizeMax = new Vector2(10.0f, 10.0f);
    public Vector2 platformSpawnSizeMin = new Vector2(5.0f, 5.0f);

    private Vector2 bounds;

    public uint spawnPlatformCount = 10;

    List<ColliderData> platforms;

    // Start is called before the first frame update
    void Start()
    {
        var collider = GetComponent<BoxCollider>();
        bounds.x = collider.size.x / 2;
        bounds.y = collider.size.z / 2;

        for (uint i = 0; i < spawnPlatformCount; i++)
        {
            /* var included = IncludePlatform(); */
            /* if (!CollidesWithPlaced(included)) */
            /* { */
            /*     platforms.Add(included); */
            /* } */
        }
    }

    void IncludePlatform()
    {
        var sizeX = Random.Range(platformSpawnSizeMin.x, platformSpawnSizeMax.x);
        var sizeY = Random.Range(platformSpawnSizeMin.y, platformSpawnSizeMax.y);
        var locationX = Random.Range(-bounds.x, bounds.x);
        var locationY = Random.Range(-bounds.y, bounds.y);
    }

    bool CollidesWithPlaced(ColliderData data)
    {
        return false;
    }
}
