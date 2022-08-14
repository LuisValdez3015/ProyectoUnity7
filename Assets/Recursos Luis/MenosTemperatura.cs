using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenosTemperatura : MonoBehaviour
{
    [SerializeField] Temperatura temperatura;

    [SerializeField] GameObject pressG;

    public AudioSource botonSonido;

    private void OnTriggerStay(Collider other)
    {
       
        Debug.Log("Pressed");
        var playercontroller = other.gameObject.GetComponent<PlayerController>();
        if (playercontroller == null)
            return;

        pressG.SetActive(true);

        if (tag == "MenosTemperatura")
        {
            if (Input.GetKey(KeyCode.G) && temperatura.TemperatureOnPoint >= 0)
            {
                temperatura.TemperatureOnPoint = (float)(temperatura.TemperatureOnPoint - 0.1);
                pressG.SetActive(false);
                botonSonido.Play();
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        pressG.SetActive(false);
    }
}
