using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cerrojo2 : MonoBehaviour
{

    [SerializeField] public int id;
    [SerializeField] public int playerId;

    bool isDooropen;
    public Animator anim;

    [SerializeField] Image imgPlayerHUD;

    [SerializeField] GameObject pressG;

    [SerializeField] Image imgNeedKey;

    [SerializeField] GameObject llave2Cocina;

    [SerializeField] GameObject llave1Cocina;

    public void OpenDoor()
    {
        anim.SetTrigger("Idle");
        //Sonido 
        llave2Cocina.SetActive(true);
        llave1Cocina.SetActive(false);
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
                if (Input.GetKey(KeyCode.G))
                {
                    pressG.gameObject.SetActive(false);
                    playercontroller.ConsumeKey(id);
                    imgPlayerHUD.gameObject.SetActive(false);
                    OpenDoor();
                    isDooropen = true;
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
