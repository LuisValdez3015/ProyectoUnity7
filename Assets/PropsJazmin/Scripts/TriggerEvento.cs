using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvento : MonoBehaviour
{
    [SerializeField] private UnityEvent animacionEntrar = default;
    [SerializeField] private UnityEvent animacionSalir = default;

    [SerializeField] GameObject objetoEntrar;
    [SerializeField] GameObject objetoSalir;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == objetoEntrar)
        {
            animacionEntrar?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == objetoSalir)
        {
            animacionSalir?.Invoke();
        }
    }
}
