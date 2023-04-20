using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoPointRamp : MonoBehaviour
{
    [SerializeField]
    private Vector3 topPoint;
    [SerializeField]
    private Vector3 bottomPoint;
    private BoxCollider boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();

        if (transform.rotation.x == 0)
        {
            topPoint =
                boxCollider.center +
                transform.position +
                new Vector3((boxCollider.size.x / 2) * transform.localScale.x, (boxCollider.size.x / 2) * transform.localScale.x, 0.0f);
            bottomPoint =
                boxCollider.center +
                transform.position +
                new Vector3(-(boxCollider.size.x / 2) * transform.localScale.x, -(boxCollider.size.x / 2) * transform.localScale.x, 0.0f);
        }
        else if (transform.rotation.z == 0)
        {
            topPoint =
                boxCollider.center +
                transform.position +
                new Vector3(0.0f, (boxCollider.size.z / 2) * transform.localScale.z, -(boxCollider.size.z / 2) * transform.localScale.z);
            bottomPoint =
                boxCollider.center +
                transform.position +
                new Vector3(0.0f, -(boxCollider.size.z / 2) * transform.localScale.z, (boxCollider.size.z / 2) * transform.localScale.z);
        }
        else
        {
            Debug.LogError("This should not happen, go yell at David.");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
