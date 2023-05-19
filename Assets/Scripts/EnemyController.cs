using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float speed = 0.5f;

    private NavMeshAgent navAgent;
    private Taggable taggable;
    private TagManager tagManager;

    private Vector3 lastGotoPoint;

    // Start is called before the first frame update
    void Start()
    {
        tagManager = TagManager.GetTagManager();
        navAgent = GetComponent<NavMeshAgent>();
        taggable = GetComponent<Taggable>();
        lastGotoPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.GetGameManager().isGameOver)
            return;

        if (taggable.GetCanTag())
        {
            navAgent.speed = speed;
            var closest = tagManager.FindNearestPlayer(transform);
            navAgent.SetDestination(closest.position + Vector3.up);
            lastGotoPoint = transform.position;
        }
        else
        {
            if (Vector3.Distance(lastGotoPoint, transform.position) < 5.0f)
            {
                var taggerPosition = tagManager.GetWhoIsIt().transform.position;
                var dst = EnemyController.FindBestDestination(taggerPosition);
                navAgent.SetDestination(dst);
                lastGotoPoint = dst;
            }
        }
    }

    IEnumerator UpdateChaser()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            tagManager.FindNearestPlayer(transform);
        }
    }

    static List<(float, Vector3)> SortArray(ref List<(float, Vector3)> zipped)
    {
        var n = zipped.Count;
        for (int i = 0; i < n - 1; i++)
            for (int j = 0; j < n - i - 1; j++)
                if (zipped[j].Item1 > zipped[j + 1].Item1)
                {
                    var tempVar = zipped[j];
                    zipped[j] = zipped[j + 1];
                    zipped[j + 1] = tempVar;
                }
        return zipped;
    }

    static Vector3 FindBestDestination(Vector3 taggerPosition)
    {
        var pepperonis = SubdivideGround.GetAllPoints();
        var pepperonisWeights = new List<float>();

        foreach (var pepperoni in pepperonis)
        {
            var val = (Vector3.Dot(taggerPosition.normalized, pepperoni.normalized) * -1 + 1) / 2;
            pepperonisWeights.Add(val);
        }

        float totalWeight = 0.0f;

        foreach (var weight in pepperonisWeights)
        {
            totalWeight += weight;
        }

        var zippedPepperonis = new List<(float, Vector3)>();

        for (int i = 0; i < pepperonis.Count; i++)
        {
            zippedPepperonis.Add((pepperonisWeights[i], pepperonis[i]));
        }

        var sortedZippedPepperonis = SortArray(ref zippedPepperonis);

        float cumulativeWeight = 0.0f;
        float randomNumber = Random.Range(0.0f, totalWeight);

        foreach (var (weight, pepperoni) in sortedZippedPepperonis)
        {
            cumulativeWeight += weight;
            if (randomNumber < cumulativeWeight)
            {
                return pepperoni;
            }
        }

        int randomIndex = Random.Range(0, pepperonis.Count);
        return pepperonis[randomIndex];
    }
}
