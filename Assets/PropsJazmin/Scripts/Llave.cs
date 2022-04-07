using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llave : MonoBehaviour
{
    public int id;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("1");
        var playercontroller = other.gameObject.GetComponent<PlayerController>();
        if (playercontroller == null)
            return;
        Debug.Log("2");
        playercontroller.Addkey(id);

        Destroy(this.gameObject);
    }
}
