using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float horizontalInput;
    float verticalInput;
    private Rigidbody playerRb;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //horizontal movement
        //playerRb.AddForce(Vector3.right * Time.deltaTime * horizontalInput * 500,ForceMode.Acceleration);
        //playerRb.AddForce(Vector3.forward * Time.deltaTime * verticalInput * 500, ForceMode.Acceleration);
        transform.Translate(Vector3.forward * verticalInput);
/*
        //look at mouse
        Ray ray;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Collider.Raycast(ray, out hit, 1000))
        {
            // planeCollider should be a Box Collider that the mouse can click
            // hit.point is the point of the mouse click

        }*/
    }
}
