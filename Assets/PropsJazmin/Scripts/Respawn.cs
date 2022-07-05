using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private GameObject cojin;
    [SerializeField] private Transform respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        cojin.transform.position = respawnPoint.transform.position;
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    cojin.transform.position = respawnPoint.transform.position;
    //}

}
