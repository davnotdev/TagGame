using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBack : MonoBehaviour
{
    private Rigidbody rb;
    private float pushBackSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void PushMeBack(Vector3 from) {
        var direction = (transform.position - from).normalized;
        rb.AddForce(direction * pushBackSpeed, ForceMode.Impulse);
    }
}
