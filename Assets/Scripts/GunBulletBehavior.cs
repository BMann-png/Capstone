using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBulletBehavior : MonoBehaviour
{
    [Range(1, 100)] [SerializeField] float Speed;
    [SerializeField] float DecayTime = 4;

    // Start is called before the first frame update
    void Start()
    {
        if (TryGetComponent<Rigidbody>(out Rigidbody rb))
        {
            rb.AddForce(transform.up * Speed * 10, ForceMode.Impulse);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        DecayTime -= Time.deltaTime;

        if (DecayTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
