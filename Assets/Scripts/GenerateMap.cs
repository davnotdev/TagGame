using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct ColliderData {
    Vector2 center;
    Vector2 size;
}

public class GenerateMap : MonoBehaviour
{
    public Vector2 platformSpawnSizeMax = new Vector2(10.0f, 10.0f);
    public Vector2 platformSpawnSizeMin = new Vector2(5.0f, 5.0f); 

    public uint spawnPlatformCount = 10;

    List<ColliderData> platforms;

    // Start is called before the first frame update
    void Start()
    {
        for(uint i = 0; i < spawnPlatformCount; i++) 
        {
            var included = IncludePlatform();
            if (!CollidesWithPlaced(included)) {
                platforms.Add(included);
            }
        }
    }

    ColliderData IncludePlatform() {
        
    }

    bool CollidesWithPlaced(ColliderData data) 
    {
        return false;
    }
}
