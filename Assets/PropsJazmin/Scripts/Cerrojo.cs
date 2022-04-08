using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cerrojo : MonoBehaviour
{
    //public GameObject door;
    bool isDooropen;
    public int id;
    //public AudioClip clip;
    public Animator anim;

    //public void Awake()
    //{
    //    anim = GetComponent<Animator>();
    //}

    public void OpenDoor()
    {
        anim.SetBool("Abrir", true);
    }

    private void OnTriggerEnter(Collider other)
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
                playercontroller.ConsumeKey(id);
                OpenDoor();
                isDooropen = true;
            }
        }
    }
}
