using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float speed = 0.5f;

    private NavMeshAgent navAgent;
    private Taggable taggable;
    private TagManager tagManager;

    // Start is called before the first frame update
    void Start()
    {
        tagManager = TagManager.GetTagManager();
        navAgent = GetComponent<NavMeshAgent>();
        taggable = GetComponent<Taggable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (taggable.GetCanTag())
        {
            navAgent.speed = speed;
            var closest = tagManager.FindNearestPlayer(transform);
            navAgent.SetDestination(closest.position + Vector3.up);
        }
        else
        {
            //  TODO: Very naive implementation.
            navAgent.SetDestination(transform.position - (tagManager.GetWhoIsIt().transform.position - transform.position).normalized);
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
}
