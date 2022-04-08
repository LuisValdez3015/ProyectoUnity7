using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColocarLlave : MonoBehaviour
{
    [SerializeField] public int id;
    [SerializeField] public int playerId;
    [SerializeField] GameObject key;

    public bool hasKey;

    private void OnTriggerEnter(Collider other)
    {
        var playercontroller = other.gameObject.GetComponent<PlayerController>();
        if (playercontroller == null)
            return;
        if (playerId == playercontroller.playerId)
        {
            if (playercontroller.HasKey(id))
            {
                playercontroller.ConsumeKey(id);
                key.gameObject.SetActive(true);
                hasKey = true;
            }
        }
        else
        {
            return;
        }
    }

}
