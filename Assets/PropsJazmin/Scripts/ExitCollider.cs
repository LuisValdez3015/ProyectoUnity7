using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitCollider : MonoBehaviour
{
    public Animator anim;
    public AudioSource seAbrePiedra;

    public void AnimacionCuerda()
    {
        anim.SetBool("Cuerda", true);
        seAbrePiedra.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Cilindro")
        {
            AnimacionCuerda();
        }
    }
}
