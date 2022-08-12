using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePlatform : MonoBehaviour
{
    //public bool isActive = true;

    [SerializeField] public float bounceForce = default;
    public AudioSource cojinbota;


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerMovimiento>().Bounce(bounceForce);
            cojinbota.Play();
        }
    }
}
