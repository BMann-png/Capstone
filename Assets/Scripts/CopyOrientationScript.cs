using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyOrientationScript : MonoBehaviour
{
    [SerializeField] Transform ThisRotation;
    [SerializeField] Transform OtherRotation;


    // Update is called once per frame
    void Update()
    {
        ThisRotation.rotation = OtherRotation.rotation;
    }
}
