using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatePowerUp : MonoBehaviour
{
    public int rotationSpeed = 75;
    public Vector3 whichDirection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(whichDirection * rotationSpeed * Time.deltaTime);
    }
}
