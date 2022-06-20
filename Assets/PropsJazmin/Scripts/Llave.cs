using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Llave : MonoBehaviour
{
    [SerializeField] GameObject imgPlayer;

    public int id;

    private void OnTriggerEnter(Collider other)
    {
        var playercontroller = other.gameObject.GetComponent<PlayerController>();
        if (playercontroller == null)
            return;
        playercontroller.Addkey(id);
        imgPlayer.gameObject.SetActive(true);
        Destroy(this.gameObject);
    }

}
