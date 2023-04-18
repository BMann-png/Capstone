using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] CharacterController CC;
    [SerializeField] PlayerInput PI;
    [SerializeField] Animator ani;
    [SerializeField] [Range(1, 10)] float Speed = 5;

    private Vector2 Move;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CC.Move(transform.forward * -PI.actions["Move"].ReadValue<Vector2>().y * Speed * Time.deltaTime);
        transform.Rotate(Vector3.up * 90 * Time.deltaTime * PI.actions["Move"].ReadValue<Vector2>().x);

        ani.SetFloat("Speed", Mathf.Abs(PI.actions["Move"].ReadValue<Vector2>().y));
        //ani.SetBool("IsDancing", Input.GetMouseButton(0));
    }
}
