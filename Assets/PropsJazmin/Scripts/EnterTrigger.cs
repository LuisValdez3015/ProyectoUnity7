using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterTrigger : MonoBehaviour
{
    public Animator anim;

    public void AnimacionLlave()
    {
        anim.SetTrigger("LlaveT");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Llave")
        {
            AnimacionLlave();
        }
    }
}
