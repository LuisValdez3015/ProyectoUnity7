using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cerrojo : MonoBehaviour
{
    public float speed;
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
        //door.transform.position += transform.up * speed * Time.deltaTime;
        anim.SetBool("Abrir", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isDooropen)
        {
            GameManager gamemanager = FindObjectOfType<GameManager>();
            if (gamemanager.HasKey(id))
            {
                gamemanager.ConsumeKey(id);
                OpenDoor();
                isDooropen = true;
                this.gameObject.SetActive(false);

            }
        }
    }
}
