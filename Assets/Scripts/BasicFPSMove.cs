using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicFPSMove : MonoBehaviour
{
    private Vector2 LastMousePos = Vector2.zero;
    void Start()
    {
        
    }

    void Update()
    {
        Rigidbody r = GetComponent<Rigidbody>();
        if (r.velocity.magnitude < 10)
        {
            if (Input.GetKey(KeyCode.W))
            {
                //transform.position += (transform.forward * 20 * Time.deltaTime);
                r.AddForce(transform.forward * 1000 * Time.deltaTime, ForceMode.Acceleration);
            }
            if (Input.GetKey(KeyCode.S))
            {
                //transform.position += (transform.forward * -20 * Time.deltaTime);
                r.AddForce(transform.forward * -1000 * Time.deltaTime, ForceMode.Acceleration);
            }
            if (Input.GetKey(KeyCode.D))
            {
                //transform.position += (transform.right * 20 * Time.deltaTime);
                r.AddForce(transform.right * 1000 * Time.deltaTime, ForceMode.Acceleration);
            }
            if (Input.GetKey(KeyCode.A))
            {
                //transform.position += (transform.right * -20 * Time.deltaTime);
                r.AddForce(transform.right * -1000 * Time.deltaTime, ForceMode.Acceleration);
            }
        }
        
        transform.Rotate(Vector3.up * 30 * Time.deltaTime * (Input.mousePosition.x - LastMousePos.x));

        LastMousePos = Input.mousePosition;
    }
}
