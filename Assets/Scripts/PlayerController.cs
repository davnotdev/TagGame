using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float horizontalInput;
    float verticalInput;
    private float speed = 5;
    private float lookSpeed = 100;
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
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        //temporary turning code to make sure that the forces work
        if (Input.GetKey(KeyCode.U))
        {
            transform.Rotate(-Vector3.up * Time.deltaTime * lookSpeed);
        }

        if (Input.GetKey(KeyCode.I))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * lookSpeed);
        }


        /*
         * david's spaghetti code
         * //look at mouse
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
