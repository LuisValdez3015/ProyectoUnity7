using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonElevador1 : MonoBehaviour
{
    [SerializeField] GameObject verde1;

    [SerializeField] GameObject pressG;

    public Animator botonClick;
    public Animator puertaCerrar;
    public Animator puertaAbrir;

    [SerializeField] BoxCollider boxColliderBoton;

    public AudioSource elevadorSonido;
    public AudioSource botonSonidoElevador;
    public AudioSource bibliotecaAbre;

    //public GameObject characterSwap;

    public void OnTriggerStay(Collider other)
    {
        pressG.SetActive(true);
        if (Input.GetKey(KeyCode.G))
        {
            botonClick.SetBool("Click", true);
            botonSonidoElevador.Play();
            verde1.SetActive(true);
            puertaCerrar.SetBool("Cerrar", true);
            elevadorSonido.Play();
            puertaAbrir.SetBool("Abrir", true);
            bibliotecaAbre.Play();
            pressG.SetActive(false);
            boxColliderBoton.enabled = false;

            //characterSwap.GetComponent<CharacterSwap>().Swap();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        pressG.SetActive(false);

    }
}
