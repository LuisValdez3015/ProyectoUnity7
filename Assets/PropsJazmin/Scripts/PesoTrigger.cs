using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PesoTrigger : MonoBehaviour
{
    [SerializeField] GameObject pechero;
    [SerializeField] GameObject mesa;
    [SerializeField] GameObject toolbag;
    [SerializeField] GameObject maceta;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Pechero")
        {
            pechero.SetActive(true);
        }
        if (other.gameObject.name == "Maceta")
        {
            mesa.SetActive(true);
        }
        if (other.gameObject.name == "Toolbag")
        {
            toolbag.SetActive(true);
        }
        if (other.gameObject.name == "Mesa")
        {
            maceta.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Pechero")
        {
            pechero.SetActive(false);
        }
        if (other.gameObject.name == "Maceta")
        {
            mesa.SetActive(false);
        }
        if (other.gameObject.name == "Toolbag")
        {
            toolbag.SetActive(false);
        }
        if (other.gameObject.name == "Mesa")
        {
            maceta.SetActive(false);
        }
    }
}
