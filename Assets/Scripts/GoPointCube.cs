using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoPointCube : MonoBehaviour, IGoPoint
{
    [SerializeField]
    private List<Vector3> goPoints;
    private BoxCollider boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        goPoints = new List<Vector3>();

        goPoints.Add(
            boxCollider.center + 
            new Vector3(boxCollider.size.x * transform.localScale.x, boxCollider.size.y * transform.localScale.y, 0.0f)
        );
        goPoints.Add(
            boxCollider.center + 
            new Vector3(-boxCollider.size.x * transform.localScale.x, boxCollider.size.y * transform.localScale.y, 0.0f)
        );
        goPoints.Add(
            boxCollider.center + 
            new Vector3(0.0f, boxCollider.size.y * transform.localScale.y, boxCollider.size.z * transform.localScale.z)
        );
        goPoints.Add(
            boxCollider.center + 
            new Vector3(0.0f, boxCollider.size.y * transform.localScale.y, -boxCollider.size.z * transform.localScale.z)
        );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<Vector3> GetPoints() {
        return goPoints;
    }
}
