using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCheckpoint : MonoBehaviour
{
    private GameObject checkPoint;

    private PlayerController playerController;

    private void Start()
    {
        playerController.SetNewSpawnPoint(transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        player.SetNewSpawnPoint(transform.position);
            
        if (!other.CompareTag("Player"))
        {
            player.SetNewSpawnPoint(checkPoint.transform.position);
        }        

        //PlayerController player = other.GetComponent<PlayerController>();

        //player.SetNewSpawnPoint(transform.position);

        //if (other.gameObject.CompareTag("Checkpoint"))
        //{
        //    player.SetNewSpawnPoint(checkPoint.transform.position);
        //}

    }
}
