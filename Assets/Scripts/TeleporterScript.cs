using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterScript : MonoBehaviour
{
    [SerializeField] Transform LinkedTeleporter;

    float teleportCooldown = 5;

    private void Update()
    {
        teleportCooldown -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(teleportCooldown <= 0)
        {
            other.transform.position = LinkedTeleporter.position;
        }
    }
}
