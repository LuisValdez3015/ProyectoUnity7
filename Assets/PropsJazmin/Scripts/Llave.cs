using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llave : MonoBehaviour
{
    public int id;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);

        GameManager gamemanager = FindObjectOfType<GameManager>();
        gamemanager.AddKey(id);
    }
}
