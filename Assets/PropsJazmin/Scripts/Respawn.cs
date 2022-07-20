using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] GameObject cojin;
    [SerializeField] Transform respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (!cojin.Equals(other.gameObject))
            return;

        Rigidbody r = cojin.GetComponent<Rigidbody>();

        r.useGravity = true;
        r.isKinematic = false;
        r.mass = 1;

        cojin.transform.position = respawnPoint.transform.position;
    }
}
