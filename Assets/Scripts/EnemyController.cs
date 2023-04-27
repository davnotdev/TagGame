using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float speed = 0.5f;
    public Transform chaseThis;

    private NavMeshAgent navAgent;
    private Taggable taggable;
    private TagManager tagManager;

    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        taggable = GetComponent<Taggable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (taggable.GetCanTag())
        {
            navAgent.speed = speed;
            navAgent.SetDestination(chaseThis.transform.position + Vector3.up);
        }
        else
        {
            
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
