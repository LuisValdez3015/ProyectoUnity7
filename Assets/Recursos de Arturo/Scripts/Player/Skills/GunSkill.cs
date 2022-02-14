using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSkill : PlayerSkill
{
    private float ShootTarget;

    [SerializeField] private float range = 3f;
    //[SerializeField] private float impactForce = 30f;
    [SerializeField] private float fireRate = 5f;

    [SerializeField] private int maxAmmo = 10;
    [SerializeField] private int currentAmmo;
    [SerializeField] private float reloadTime = 1f;
    [SerializeField] private bool isReloading = false;

    [SerializeField] private Camera tpsGun;

    //[SerializeField] private LayerMask LayerMask = default;

    [SerializeField] private GameObject impactEffect;

    [SerializeField] private GameObject gun;

    [SerializeField] public AudioClip impactAudio;

    [SerializeField] public AudioClip flybyAudio;

    private float nextTimeToFire = 0f;

    private void Start()
    {
        currentAmmo = maxAmmo;
    }

    void Update()
    {
        if (!isActive)
        {
            return;
        }

        if (isReloading)
        {
            return;
        }

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        Debug.DrawRay(tpsGun.transform.position, tpsGun.transform.forward * range, Color.red);
        if (Input.GetMouseButtonDown(0) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            ShootSkill();
            AudioSource.PlayClipAtPoint(flybyAudio, transform.position, 0.6f);

        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");

        yield return new WaitForSeconds(reloadTime);

        Debug.Log("Reloaded...");
        currentAmmo = maxAmmo;
        isReloading = false;
    }

    private void ShootSkill()
    {
        currentAmmo--;

        RaycastHit hit;

        if (Physics.Raycast(tpsGun.transform.position, tpsGun.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Vector3 hitpoint = hit.point;

            Vector3 gunposition = gun.transform.position;

            Vector3 direction = (hitpoint - gunposition).normalized;

            AudioSource.PlayClipAtPoint(impactAudio, hitpoint);

            RaycastHit hit2;

            if (Physics.Raycast (gunposition, direction, out hit2, range))
            {
                Target target = hit2.transform.GetComponent<Target>();
                if (target != null)
                {
                    target.HitTarget(ShootTarget);
                }

                

                GameObject impactGo = Instantiate(impactEffect, hit2.point + hit2.normal * 0.0001f, Quaternion.LookRotation(hit2.normal));

                Destroy(impactGo, 2f);

                Debug.DrawLine(gunposition, hit2.point, Color.blue);
            }

            

            //Empuja una nada las cajitas
            //if (hit.rigidbody != null)
            //{
            //    hit.rigidbody.AddForce(-hit.normal * impactForce);
            //}
        }
    }

    //void HitEffect()
    //{
    //    RaycastHit hit;

    //    if (Physics.Raycast(tpsGun.transform.position, tpsGun.transform.forward, out hit, range))
    //    {
    //    }
    //}
}
