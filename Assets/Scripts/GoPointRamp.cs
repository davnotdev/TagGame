using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoPointRamp : MonoBehaviour, IGoPoint
{
    [SerializeField]
    private List<Vector3> goPoints;
    private BoxCollider boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        goPoints = new List<Vector3>();

        if (transform.rotation.x == 0) 
        {
            goPoints.Add(
                boxCollider.center + 
                transform.position +
                new Vector3((boxCollider.size.x / 2) * transform.localScale.x, (boxCollider.size.x / 2) * transform.localScale.x, 0.0f)
            );
            goPoints.Add(
                boxCollider.center + 
                transform.position +
                new Vector3(-(boxCollider.size.x / 2) * transform.localScale.x, -(boxCollider.size.x / 2) * transform.localScale.x, 0.0f)
            );
        } 
        else if (transform.rotation.z == 0)
        {
            goPoints.Add(
                boxCollider.center + 
                transform.position +
                new Vector3(0.0f, (boxCollider.size.z / 2) * transform.localScale.z, -(boxCollider.size.z / 2) * transform.localScale.z)
            );
            goPoints.Add(
                boxCollider.center + 
                transform.position +
                new Vector3(0.0f, -(boxCollider.size.z / 2) * transform.localScale.z, (boxCollider.size.z / 2) * transform.localScale.z)
            );
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<Vector3> GetPoints() 
    {
        return goPoints;
    }
}
