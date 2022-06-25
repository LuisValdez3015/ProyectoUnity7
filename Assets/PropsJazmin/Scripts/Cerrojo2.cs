using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cerrojo2 : MonoBehaviour
{

    [SerializeField] public int id;
    [SerializeField] public int playerId;

    bool isDooropen2;
    public Animator anim;

    [SerializeField] Image imgPlayerHUD;

    [SerializeField] GameObject pressG;

    [SerializeField] Image imgNeedKey;

    [SerializeField] Cerrojo cerrojo;

    [SerializeField] GameObject cerrojoEscondido;

    [SerializeField] GameObject cerrojoDesactivarlo;

    public void OpenDoor()
    {
        anim.SetTrigger("Idle");
        //Sonido 
    }

    private void OnTriggerStay(Collider other)
    {
        if (!isDooropen2)
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
                if (Input.GetKey(KeyCode.G))
                {
                    pressG.gameObject.SetActive(false);
                    playercontroller.ConsumeKey(id);
                    imgPlayerHUD.gameObject.SetActive(false);
                    cerrojoEscondido.SetActive(true);
                    isDooropen2 = true;
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
