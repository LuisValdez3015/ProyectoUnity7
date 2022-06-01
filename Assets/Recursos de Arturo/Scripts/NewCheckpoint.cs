using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCheckpoint : MonoBehaviour
{

    private PlayerController playerController;

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        Debug.Log("checkpoint trigger with " + other.gameObject.name, other.gameObject);

        if (other.CompareTag("Player"))
        {
            player.SetNewSpawnPoint(transform.position);
        }        

        //PlayerController player = other.GetComponent<PlayerController>();

        //player.SetNewSpawnPoint(transform.position);

        //if (other.gameObject.CompareTag("Checkpoint"))
        //{
        //    player.SetNewSpawnPoint(checkPoint.transform.position);
        //}

    }
}
