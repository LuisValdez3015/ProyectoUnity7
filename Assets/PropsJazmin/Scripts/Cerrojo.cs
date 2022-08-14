using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cerrojo : MonoBehaviour
{
    [SerializeField] public int id;
    [SerializeField] public int playerId;

    [SerializeField] Image imgPlayerHUD;

    [SerializeField] GameObject pressG;

    [SerializeField] Image imgNeedKey;

    [SerializeField] GameObject cerrojoDesactivarlo;
    public AudioSource algoFaltante;
    public AudioSource seAbrePuerta;
    public AudioSource entraLlave;

    bool isDooropen;
    public Animator anim;


    public void OpenDoor()
    {
        anim.SetBool("Abrir", true);
        seAbrePuerta.Play();
    }

    private void OnTriggerStay(Collider other)
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
                pressG.gameObject.SetActive(true);
                imgNeedKey.gameObject.SetActive(false);
                if (Input.GetKeyDown(KeyCode.G))
                {
                    entraLlave.Play();
                    pressG.gameObject.SetActive(false);
                    playercontroller.ConsumeKey(id);
                    imgPlayerHUD.gameObject.SetActive(false);
                    OpenDoor();
                    isDooropen = true;
                    cerrojoDesactivarlo.SetActive(false);

                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var playercontroller = other.gameObject.GetComponent<PlayerController>();
        if (playercontroller == null)
            return;

        imgNeedKey.gameObject.SetActive(true);
        if (!playercontroller.HasKey(id))
        {
            algoFaltante.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var playercontroller = other.gameObject.GetComponent<PlayerController>();
        if (playercontroller == null)
            return;

        imgNeedKey.gameObject.SetActive(false);
        pressG.gameObject.SetActive(false);
    }
}
