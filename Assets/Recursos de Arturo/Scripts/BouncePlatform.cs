using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePlatform : MonoBehaviour
{
    [SerializeField] public float bounceForce = default;

    //private void OnCollisionEnter(Collision collision)
    //{   
    //    Debug.Log(collision.gameObject + " collision with " + collision.gameObject.name, collision.gameObject);

    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        collision.gameObject.GetComponent<PlayerMovimiento>().Bounce(bounceForce);
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject + " trigger with " + other.gameObject.name, other.gameObject);

        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerMovimiento>().Bounce(bounceForce);
        }
    }
}
