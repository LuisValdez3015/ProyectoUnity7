using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitCollider : MonoBehaviour
{
    public Animator anim;

    public void AnimacionCuerda()
    {
        anim.SetBool("Cuerda", true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Cilindro")
        {
            AnimacionCuerda();
        }
    }
}
