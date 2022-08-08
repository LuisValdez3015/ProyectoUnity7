using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttach : MonoBehaviour
{
    //public GameObject Player1;

    //public GameObject Player2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.parent = transform;
        }

        //if (other.gameObject == Player2)
        //{
        //    Player2.transform.parent = transform;
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.parent = null;
        }

        //if (other.gameObject == Player2)
        //{
        //    Player2.transform.parent = transform;
        //}
    }
}
