using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TagManager : MonoBehaviour
{
    [SerializeField]
    GameObject whoIsIt;
    [SerializeField]
    List<GameObject> players;

    public void Begin() 
    {
        foreach (var obj in FindObjectsOfType<Taggable>())
        {
            players.Add(obj.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Transform FindNearestPlayer(Transform transform)
    {
        const float yFactor = 1.0f;
        Transform closest = null;
        float minDistance = Mathf.Infinity;
        foreach (var player in players)
        {
            if (player.GetInstanceID() != whoIsIt.GetInstanceID())
            {
                var biasedPlayerPosition = new Vector3(
                    player.transform.position.x,
                    player.transform.position.y * yFactor,
                    player.transform.position.z
                );
                var distance = Vector3.Distance(biasedPlayerPosition, transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closest = player.transform;
                }
            }
        }
        return closest;
    }

    public void SetWhoIsIt(GameObject who)
    {
        whoIsIt = who;
    }

    public GameObject GetWhoIsIt()
    {
        return whoIsIt;
    }

    public static TagManager GetTagManager() {
        return GameObject.Find("TagManager").GetComponent<TagManager>();
    }
}
