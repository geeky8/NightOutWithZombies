using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public Rigidbody rb;
    public float speed = 10f;
    float xInput;
    float zInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        rb.AddForce(xInput * speed, 0, 0);
        zInput = Input.GetAxis("Vertical");
        rb.AddForce(0, 0, zInput * speed);
    }

    
}
