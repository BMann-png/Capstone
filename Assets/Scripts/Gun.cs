using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject BulletSpawn;
    [SerializeField] GameObject BulletPrefab;
    [SerializeField] float recoilAmount = 100;
    [SerializeField] GameObject[] hands;

    void Update()
    {
        //if (Input.GetMouseButton(0))
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(BulletPrefab, BulletSpawn.transform.position, BulletSpawn.transform.rotation);

            foreach (GameObject h in hands)
            {
                Vector2 randVect = Random.insideUnitCircle.normalized;

                Vector3 rand3DVect = new Vector3(randVect.x, Mathf.Abs(randVect.y), 0);


                if (h.TryGetComponent<Rigidbody>(out Rigidbody rb))
                {
                    rb.AddForceAtPosition(rand3DVect * recoilAmount, BulletSpawn.transform.position);
                }
            }
;
        }
    }
}
