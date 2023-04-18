using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Physics_Dragger : MonoBehaviour
{
    [SerializeField] float speed = 0;
    private Vector3 initialPos;
    GameObject launchObject;
    bool mouseDown = false;
    [SerializeField] Camera cam;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.forward * -speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.right * -speed * Time.deltaTime);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitData;

            if (Physics.Raycast(ray, out hitData))
            {
                initialPos = hitData.point;

                Debug.Log("Hit!");
                Debug.Log(initialPos);
                Debug.DrawRay(ray.origin, ray.direction, Color.green);

                if (hitData.collider.gameObject.TryGetComponent<Rigidbody>(out Rigidbody rb))
                {
                    launchObject = rb.gameObject;
                    mouseDown = true;
                }
            }
            
        }
        

        if (Input.GetMouseButtonUp(0))
        {
            mouseDown = false;
            launchObject = null;
        }
    }

    private void FixedUpdate()
    {
        if (mouseDown)
        {
            //Vector3 forceVector = Camera.main.ScreenToWorldPoint(Input.mousePosition) - initialPos;
            float distance = (transform.position - initialPos).magnitude;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            Vector3 LocalIntendedPos = ray.direction * distance;
            Vector3 WorldIntendedPos = transform.position + LocalIntendedPos;
            Vector3 ForceDir = WorldIntendedPos - initialPos;

            launchObject.GetComponent<Rigidbody>().AddForce(ForceDir * 1, ForceMode.Force);
            //launchObject.GetComponent<Rigidbody>().AddForce(forceVector * 1, ForceMode.Impulse);
            Debug.Log("Force Applied!");
            //Debug.Log(forceVector);
        }
    }
}
