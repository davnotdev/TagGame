using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubdivideGround : MonoBehaviour
{
    BoxCollider ground;
    List<Vector3> points;

    const int N = 10;

    void Start()
    {
        points = new List<Vector3>();
        ground = GetComponent<BoxCollider>();

        var origin = ground.center - new Vector3(ground.bounds.size.x / 2, 0.0f, ground.bounds.size.z / 2);
        var xDiv = ground.bounds.size.x / N;
        var yDiv = ground.bounds.size.z / N;
        for (int xI = 0; xI < N + 1; xI++)
        {
            for (int yI = 0; yI < N + 1; yI++)
            {
                var p = origin + new Vector3(xI * xDiv, transform.position.y, yI * yDiv);
                points.Add(p);
            }
        }
    }

    List<Vector3> GetPoints()
    {
        return points;
    }

    public static List<Vector3> GetAllPoints()
    {
        var total = new List<Vector3>();
        var objects = GameObject.FindObjectsOfType<SubdivideGround>();
        foreach (var sub in objects)
        {
            var points = sub.GetPoints();
            foreach (var point in points)
            {
                total.Add(point);
            }
        }
        return total;
    }
}
