using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoRocks : MonoBehaviour
{
    private PlayerController playerController;
    public AudioSource recargar;

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        Debug.Log("Full ammo/rocks" + other.gameObject.name, other.gameObject);

        if (other.CompareTag("Player"))
        {
            GunSkill gunSkill = other.GetComponentInChildren<GunSkill>();

            gunSkill.FullAmmoTrigger();
            recargar.Play();
        }


    }
}
