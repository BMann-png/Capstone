using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [Range(1, 100)][SerializeField] float Speed;
    [SerializeField] float DecayTime = 4;

    private void Start()
    {
        if (TryGetComponent<Rigidbody>(out Rigidbody rb))
        {
            rb.AddForce(transform.forward * Speed * 10, ForceMode.Impulse);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        DecayTime -= Time.deltaTime;

        if (DecayTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.GetContact(0).otherCollider.TryGetComponent<ConfigurableJoint>(out ConfigurableJoint cj))
        {
            GameObject go = cj.gameObject;
            bool isLooping = true;
            while (go.transform.parent != null && isLooping)
            {
                go = go.transform.parent.gameObject;

                isLooping = !go.TryGetComponent<RotationCopy>(out RotationCopy r);
            }
            if (go.TryGetComponent<RotationCopy>(out RotationCopy rc))
            {
                if(rc.GetLimbDamageBool()) BreakLimb(cj);

            }

        }
    }

    private void BreakLimb(ConfigurableJoint j)
    {
        if (j.TryGetComponent<ConfigurableJoint>(out ConfigurableJoint cj))
        {
                var slerpDrive = cj.slerpDrive;
                slerpDrive.positionDamper = 0;
                slerpDrive.positionSpring = 0;
                cj.slerpDrive = slerpDrive;
        }
    }
}
