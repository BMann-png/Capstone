using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCopy : MonoBehaviour
{
    [SerializeField] Transform[] targetTransforms;
    [SerializeField] GameObject[] joints;
    //This was originally a transform, and called for the local rotation in the fixed update
    //This caused the joints to not rotate to their full rotations. I'm not sure why.
    //Changing this array to an array of Quaternions fixed it though.
    [SerializeField] bool isCopyAnimation = true;
    [SerializeField] bool isCopyHips = true;
    [SerializeField] bool limbDamage = true;
    [SerializeField] Transform ragdollHips;
    private Quaternion[] startingRotations;

    [SerializeField] float PositionSpring = 1500;
    [SerializeField] float PositionDamper = 10;

    [SerializeField] Animator ani;

    private bool isRagdoll = false;
    private bool animateRagdoll = false;

    void Start()
    {
        startingRotations = new Quaternion[joints.Length];
        for (int i = 0; i < joints.Length; i++)
        {
            startingRotations[i] = joints[i].transform.localRotation;
        }
        animateRagdoll = targetTransforms.Length > 1;
        ChangeSlerp(PositionDamper, PositionSpring);
    }

    private void FixedUpdate()
    {
        if (isCopyHips)
        {
            ragdollHips.position = targetTransforms[0].position;
            ragdollHips.rotation = targetTransforms[0].rotation;
            if (ragdollHips.TryGetComponent<Rigidbody>(out Rigidbody rb))
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
        if (isCopyAnimation)
        {
            if (isRagdoll)
            {
                ChangeSlerp(PositionDamper, PositionSpring);

                isRagdoll = !isRagdoll;
            }
            if (animateRagdoll)
            {
                for (int i = 0; i < joints.Length; i++)
                {
                    ConfigurableJointExtensions.SetTargetRotationLocal(
                        joints[i].GetComponent<ConfigurableJoint>(),
                        targetTransforms[i + 1].localRotation,
                        startingRotations[i]);
                }
            }
        }
        else
        {
            if (!isRagdoll)
            {
                ChangeSlerp(0, 0);

                isRagdoll = !isRagdoll;
            }
        }
    }

    private void ChangeSlerp(float positionDamper, float positionSpring)
    {
        foreach (GameObject j in joints)
        {
            if (j.TryGetComponent<ConfigurableJoint>(out ConfigurableJoint cj))
            {
                var slerpDrive = cj.slerpDrive;
                slerpDrive.positionDamper = positionDamper;
                slerpDrive.positionSpring = positionSpring;
                cj.slerpDrive = slerpDrive;
            }
        }
    }

    public bool GetLimbDamageBool()
    {
        return limbDamage;
    }

    public void OnChangeDamper(string pd)
    {
        if (float.TryParse(pd, out float p))
        {
            PositionDamper = p;
            ChangeSlerp(p, PositionSpring);
        }
    }

    public void OnChangeSpring(string ps)
    {
        if (float.TryParse(ps, out float p))
        {
            PositionSpring = p;
            ChangeSlerp(PositionDamper, p);
        }
    }

    public void OnChangeHips(bool h)
    {
        isCopyHips = h;
    }

    public void OnChangeAnimation(bool a)
    {
        isCopyAnimation = a;
    }

    public void OnChangeLimbDamage(bool l)
    {
        limbDamage = l;
    }

    public void OnDance(bool d)
    {
        ani.SetBool("IsDancing", d);
    }

    public void OnWalk(bool w)
    {
        ani.SetFloat("Speed", w ? 1 : 0);
    }
}
