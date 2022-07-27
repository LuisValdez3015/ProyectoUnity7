using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LucesAD : MonoBehaviour
{
    [SerializeField] GameObject[] lucesActivar;
    [SerializeField] GameObject[] lucesDesactivar;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            for (int i = 0; i < lucesActivar.Length; i++)
            {
                lucesActivar[i].SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < lucesDesactivar.Length; i++)
            {
                lucesDesactivar[i].SetActive(false);
            }
        }
    }
}
