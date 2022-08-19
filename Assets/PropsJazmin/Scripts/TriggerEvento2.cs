using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvento2 : MonoBehaviour
{
    //[SerializeField] private UnityEvent animacionEntrar = default;
    //[SerializeField] private UnityEvent animacionSalir = default;

    [SerializeField] public Kosas;
    //[SerializeField] GameObject[] objetoSalir;

    [SerializeField] List<Kosas> cosas = new < Kosas > ();
    [SerializeField] Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == objetoEntrar[0])
        {
            anim.SetBool("Candado", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == objetoEntrar[0])
        {
            anim.SetBool("Candado", false);
        }
    }
}
