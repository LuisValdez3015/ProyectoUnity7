using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] bool isShootable;

    [SerializeField] private GameObject destroyParticles = default;

    public AudioSource abreReja;

    public bool IsShootable => isShootable;

    public void HitTarget (float amount)
    {
        GameObject particles = Instantiate(destroyParticles, transform.position, Quaternion.identity);
        Destroy(particles, 5f);

        Destroy(this.gameObject) ;
        abreReja.Play();

    }
}
