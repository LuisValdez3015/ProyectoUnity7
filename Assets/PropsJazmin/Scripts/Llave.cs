using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Llave : MonoBehaviour
{
    public int id;

    private void OnTriggerEnter(Collider other)
    {
        var playercontroller = other.gameObject.GetComponent<PlayerController>();
        if (playercontroller == null)
            return;
        playercontroller.Addkey(id);
        Destroy(this.gameObject);
    }

}
