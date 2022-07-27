using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luces : MonoBehaviour
{
    [SerializeField] GameObject luces;
    [SerializeField] Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Toolbag")
        {
            anim.SetBool("Cerraoo", true);
            luces.SetActive(false);
        }
    }
}
