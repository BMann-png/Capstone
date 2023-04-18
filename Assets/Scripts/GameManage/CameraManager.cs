using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] GameObject[] Cameras;

    public void OnCameraChanged(int c)
    {
        foreach (GameObject g in Cameras)
        {
            g.SetActive(false);
        }
        Cameras[c].SetActive(true);
    }
}
