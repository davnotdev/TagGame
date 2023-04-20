using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 0.5f;
    private Vector3 gotoPoint;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /* List<IGoPoint> GetAllGoPoints() */ 
    /* { */
    /*     var res =  new List<IGoPoint>(); */
    /*     var platforms = GameObject.FindGameObjectsWithTag("Platform"); */
    /*     foreach (var item in platforms) */
    /*     { */
    /*         res.Add(item.GetComponent<GoPointCube>()); */
    /*     } */
    /*     var ramps = GameObject.FindGameObjectsWithTag("Ramp"); */
    /*     foreach (var item in ramps) */
    /*     { */
    /*         res.Add(item.GetComponent<GoPointRamp>()); */
    /*     } */
    /*     return res; */
    /* } */
}
