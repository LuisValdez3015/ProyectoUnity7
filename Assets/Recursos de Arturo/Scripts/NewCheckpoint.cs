using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCheckpoint : MonoBehaviour
{
    [SerializeField] GameObject luciernagas;

    private PlayerController playerController;

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        if (other.CompareTag("Player"))
        {
            player.SetNewSpawnPoint(transform.position);
            luciernagas.SetActive(true);
        }        

        //PlayerController player = other.GetComponent<PlayerController>();

        //player.SetNewSpawnPoint(transform.position);

        //if (other.gameObject.CompareTag("Checkpoint"))
        //{
        //    player.SetNewSpawnPoint(checkPoint.transform.position);
        //}

    }
}
