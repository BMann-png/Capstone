using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameImplementationController : MonoBehaviour
{
    [SerializeField] GameObject ExplosionSpawn;
    [SerializeField] GameObject ExplosionPrefab;
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(ExplosionPrefab, ExplosionSpawn.transform);
        }
    }
}
