using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnter : MonoBehaviour
{
    public Animator anim;

    public void AnimacionLlave()
    {
        anim.SetTrigger("LlaveT");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Llave")
        {
            Debug.Log("Hola");
            AnimacionLlave();
        }
    }
}
