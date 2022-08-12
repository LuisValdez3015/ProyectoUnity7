using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatarInimigos : MonoBehaviour
{
    [SerializeField] Animator anim;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Enimigo"))
        {
            anim.SetTrigger("Falling");
            Destroy(other.gameObject, 3f);
        }
    }
}
