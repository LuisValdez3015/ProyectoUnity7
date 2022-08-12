using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Llave : MonoBehaviour
{
    [SerializeField] GameObject imgPlayer;
    public AudioSource tomaLlaveHorno;

    public int id;

    private void OnTriggerEnter(Collider other)
    {
        var playercontroller = other.gameObject.GetComponent<PlayerController>();
        if (playercontroller == null)
            return;
        playercontroller.Addkey(id);
        tomaLlaveHorno.Play();
        imgPlayer.gameObject.SetActive(true);
        Destroy(this.gameObject);
    }

}
