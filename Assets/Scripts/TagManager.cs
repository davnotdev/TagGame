using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> players;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var obj in FindObjectsOfType<Taggable>()) {
            players.Add(obj.gameObject);
        }
        
        //  TODO: Replace this.
        players[0].GetComponent<Taggable>().TagYouAreIt();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Transform FindNearestPlayer(Transform transform)
    {
        const float yFactor = 0.25f;
        Transform closest = players[0].transform;
        float minDistance = 9999999.0f;
        foreach (var player in players) {
            var biasedPlayerPosition = new Vector3(
                player.transform.position.x, 
                player.transform.position.y * yFactor, 
                player.transform.position.z
            );
            var distance = Vector3.Distance(biasedPlayerPosition, closest.position);
            if (distance < minDistance) 
            {
                minDistance = distance;
            }
        }
        return closest;
    }
}
