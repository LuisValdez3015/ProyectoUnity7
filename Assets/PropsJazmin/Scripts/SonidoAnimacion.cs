using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoAnimacion : MonoBehaviour
{
   [SerializeField] AudioSource sonido;


    public void SonidoActivar()
    {
        sonido.Play();
    }

    public void SonidoStop()
    {
        sonido.Stop();
    }
}
