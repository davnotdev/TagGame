using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagManager : MonoBehaviour
{
    [SerializeField]
    GameObject whoIsIt;
    [SerializeField]
    List<GameObject> players;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var obj in FindObjectsOfType<Taggable>())
        {
            players.Add(obj.gameObject);
        }

        //  TODO: Replace this.
        SetWhoIsIt(players[0]);
        whoIsIt.GetComponent<Taggable>().TagYouAreIt();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Transform FindNearestPlayer(Transform transform)
    {
        const float yFactor = 0.25f;
        //  TODO: Replace this to [0] later.
        Transform closest = players[1].transform;
        float minDistance = 9999999.0f;
        foreach (var player in players)
        {
            if (player.name != whoIsIt.name)
            {
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
