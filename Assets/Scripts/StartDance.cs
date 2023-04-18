using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDance : MonoBehaviour
{
    [SerializeField] Animator ani;

    // Start is called before the first frame update
    void Start()
    {
        ani.SetBool("IsDancing", true);
    }
}
