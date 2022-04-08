using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecogerLlave : MonoBehaviour
{
    [SerializeField] public int id;
    [SerializeField] public int playerId;
    [SerializeField] GameObject key;

    [SerializeField] ColocarLlave colocarLlave;

    private void OnTriggerEnter(Collider other)
    {
        var playercontroller = other.gameObject.GetComponent<PlayerController>();
        if (playercontroller == null)
            return;
        if (playerId == playercontroller.playerId)
        {
            if (colocarLlave.hasKey)
            {
                playercontroller.ConsumeKey(id);
                playercontroller.Addkey(id);
                key.gameObject.SetActive(false);
                colocarLlave.hasKey = false;
            }
        }
        else
        {
            return;
        }


    }

}
