using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecogerLlave : MonoBehaviour
{
    [SerializeField] public int id;
    [SerializeField] public int playerId;
    [SerializeField] GameObject key;

    [SerializeField] Image imgPlayerHUD;

    [SerializeField] GameObject pressG;

    [SerializeField] ColocarLlave colocarLlave;

    private void OnTriggerExit(Collider other)
    {
        var playercontroller = other.gameObject.GetComponent<PlayerController>();
        if (playercontroller == null)
            return;

        pressG.gameObject.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        var playercontroller = other.gameObject.GetComponent<PlayerController>();
        if (playercontroller == null)
            return;

        if (playerId == playercontroller.playerId)
        {
            if (colocarLlave.hasKey)
            {
                pressG.gameObject.SetActive(true);
                if (Input.GetKey(KeyCode.G))
                {
                    playercontroller.ConsumeKey(id);
                    playercontroller.Addkey(id);
                    key.gameObject.SetActive(false);
                    colocarLlave.hasKey = false;
                    imgPlayerHUD.gameObject.SetActive(true);
                }
            }
            else
            {
                return;
            }
        }
        else
        {
            return;
        }
    }
}
