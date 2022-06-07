using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cerrojo : MonoBehaviour
{
    [SerializeField] GameObject destornillador;
    [SerializeField] GameObject llave;

    bool isDooropen;
    public int id;
    public Animator anim;


    public void OpenDoor()
    {
        anim.SetBool("Abrir", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isDooropen)
        {
            var playercontroller = other.gameObject.GetComponent<PlayerController>();
            if (playercontroller == null)
            {
                return;
            }
            if (playercontroller.HasKey(id))
            {
                playercontroller.ConsumeKey(id);
                destornillador.SetActive(false);
                llave.SetActive(false);
                OpenDoor();
                isDooropen = true;
            }
        }

        if (other.gameObject.name == "Weaver")
        {
            destornillador.SetActive(true);
        }

        if (other.gameObject.name == "Toolbag")
        {
            llave.SetActive(true);
        }


    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Weaver")
        {
            destornillador.SetActive(false);
        }
        if (other.gameObject.name == "Toolbag")
        {
            llave.SetActive(false);
        }
    }
}
