using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitCilindros : MonoBehaviour
{
    public Animator anim;
    public Animator anim2;
    bool uno;
    bool dos;
    bool tres;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Lock1")
        {
            uno = true;
        }
        if (other.gameObject.name == "Lock2")
        {
            dos = true;
        }
        if (other.gameObject.name == "Lock3")
        {
            tres = true;
        }

        if (uno == true && dos == true)
        {
            if (tres)
            {
                anim.SetBool("Abrir", true);
                anim2.SetBool("Abrir", true);
            }
        }
    }
}
