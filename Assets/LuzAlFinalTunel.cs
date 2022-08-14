using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzAlFinalTunel : MonoBehaviour
{
    public GameObject player;

    public CharacterSwap characterSwap;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            characterSwap.Swap();
        }
    }
}

