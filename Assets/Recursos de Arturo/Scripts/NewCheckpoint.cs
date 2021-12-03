using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCheckpoint : MonoBehaviour
{
    private GameObject checkPoint;

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        player.SetNewSpawnPoint(transform.position);

        if (other.gameObject.CompareTag("Checkpoint"))
        {
            player.SetNewSpawnPoint(checkPoint.transform.position);
        }

    }
}
