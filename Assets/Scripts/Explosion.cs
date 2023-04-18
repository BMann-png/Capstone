using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] float explosionForce = 10;
    private float Timer = .1f;

    private void LateUpdate()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            Destroy(this);
        }
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Rigidbody>(out Rigidbody RG))
        {
            Vector3 distance = (other.transform.position - transform.position);
            Vector3 VerticalWeight = new Vector3 ( .9f, 2f, 0.9f );
            distance.x *= VerticalWeight.x;
            distance.y *= VerticalWeight.y;
            distance.z *= VerticalWeight.z;
            RG.AddForce((distance / distance.magnitude) * explosionForce, ForceMode.Impulse);
        }
        
        if (other.transform.parent.TryGetComponent<RotationCopy>(out RotationCopy rc))
        {
            rc.OnChangeHips(false);
            rc.OnChangeSpring("0");
            rc.OnChangeDamper("0");
        }
    }
}
