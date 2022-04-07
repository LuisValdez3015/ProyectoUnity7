using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cerrojo : MonoBehaviour
{
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
        Debug.Log("1");
        if (!isDooropen)
        {
            Debug.Log("2");
            var playercontroller = other.gameObject.GetComponent<PlayerController>();
            if (playercontroller == null)
            {
                return;
            }
            Debug.Log("3");
            if (playercontroller.HasKey(id))
            {
                Debug.Log("4");
                playercontroller.ConsumeKey(id);
                OpenDoor();
                isDooropen = true;
            }
        }
    }
}
