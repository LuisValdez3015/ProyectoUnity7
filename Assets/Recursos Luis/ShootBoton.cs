using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBoton : MonoBehaviour
{
    [SerializeField] bool isShootable;

    [SerializeField] private GameObject destroyParticles = default;

    Animator boton;

    public bool IsShootable => isShootable;

    public void HitTarget(float amount)
    {
        boton.SetBool("puerta", true);

    }
}
