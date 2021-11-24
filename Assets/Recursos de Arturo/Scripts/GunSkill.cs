using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSkill : MonoBehaviour
{
    private float ShootTarget;

    [SerializeField] private float range = 3f;
    [SerializeField] private float impactForce = 30f;
    [SerializeField] private float fireRate = 5f;

    [SerializeField] private int maxAmmo = 10;
    [SerializeField] private int currentAmmo;
    [SerializeField] private float reloadTime = 1f;
    [SerializeField] private bool isReloading = false;

    [SerializeField] private Camera tpsGun;

    [SerializeField] private LayerMask LayerMask = default;

    [SerializeField] private GameObject impactEffect;

    private float nextTimeToFire = 0f;

    private void Start()
    {
        currentAmmo = maxAmmo;
    }

    void Update()
    {
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
            HitEffect();
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

        if (Physics.Raycast(tpsGun.transform.position, tpsGun.transform.forward, out hit, range, LayerMask))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.HitTarget(ShootTarget);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
        }
    }

    void HitEffect()
    {
        RaycastHit hit;

        if (Physics.Raycast(tpsGun.transform.position, tpsGun.transform.forward, out hit, range))
        {
            GameObject impactGo = Instantiate(impactEffect, hit.point + hit.normal * 0.0001f, Quaternion.LookRotation(hit.normal));

            Destroy(impactGo, 2f);
        }
    }
}
