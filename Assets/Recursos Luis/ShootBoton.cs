using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBoton : MonoBehaviour
{
    [SerializeField] bool isShootable;

    [SerializeField] private GameObject destroyParticles = default;

    [SerializeField] Animator boton;

    public bool IsShootBoton => isShootable;

    public void HitBoton(float amount)
    {
        boton.SetBool("Puerta1", true);
        Destroy(this.gameObject);
    }
}
