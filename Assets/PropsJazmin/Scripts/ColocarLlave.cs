using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColocarLlave : MonoBehaviour
{
    [SerializeField] public int id;
    [SerializeField] public int playerId;
    [SerializeField] GameObject key;

    [SerializeField] Image imgPlayerHUD;

    [SerializeField] GameObject pressG;

    [SerializeField] Image imgNeedKey;

    [SerializeField] GameObject desactivarColocarLlave;

    public bool hasKey;

    private void OnTriggerExit(Collider other)
    {
        var playercontroller = other.gameObject.GetComponent<PlayerController>();
        if (playercontroller == null)
            return;

        imgNeedKey.gameObject.SetActive(false);

        pressG.gameObject.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        var playercontroller = other.gameObject.GetComponent<PlayerController>();
        if (playercontroller == null)
            return;

        if (playerId == playercontroller.playerId)
        {
            if (playercontroller.HasKey(id))
            {
                imgNeedKey.gameObject.SetActive(false);
                pressG.gameObject.SetActive(true);
                if (Input.GetKey(KeyCode.G))
                {
                    playercontroller.ConsumeKey(id);
                    key.gameObject.SetActive(true);
                    hasKey = true;
                    pressG.gameObject.SetActive(false);
                    imgPlayerHUD.gameObject.SetActive(false);
                    desactivarColocarLlave.SetActive(false);
                }
            }
            else
            {
                imgNeedKey.gameObject.SetActive(true);
            }
        }
        else
        {
            return;
        }
    }

}
