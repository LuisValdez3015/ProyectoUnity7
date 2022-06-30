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

    public void OnTriggerStay(Collider other)
    {
        pressG.SetActive(true);
        if (Input.GetKey(KeyCode.G))
        {
            botonClick.SetBool("Click", true);
            verde1.SetActive(true);
            puertaCerrar.SetBool("Cerrar", true);
            puertaAbrir.SetBool("Abrir", true);
        }
    }
}
