using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunSkill : PlayerSkill
{
    private float ShootTarget;

    [SerializeField] private float range = 3f;
    //[SerializeField] private float impactForce = 30f;
    [SerializeField] private float fireRate = 5f;

    [SerializeField] private int maxAmmo = 10;
    [SerializeField] private int currentAmmo;
    //[SerializeField] private float reloadTime = 1f;
    //[SerializeField] private bool isReloading = false;

    [SerializeField] private Camera tpsGun;

    //[SerializeField] private LayerMask LayerMask = default;

    [SerializeField] private GameObject impactEffect;

    [SerializeField] private Transform gun;

    [SerializeField] public AudioClip impactAudio;

    [SerializeField] public AudioClip flybyAudio;

    private float nextTimeToFire = 0f;

    [SerializeField] public Image[] rocksAmmo;
    [SerializeField] public Sprite rock;
    [SerializeField] public Sprite emptyRock;


    //[SerializeField] private Transform character;

    [SerializeField] GameObject RockAmmoCanvas;

    [SerializeField] Animator animator;

    [SerializeField] GameObject aimTarget;

    [SerializeField] float ikSmoothness = 10f;

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

        //if (isReloading)
        //{
        //    return;
        //}

        if (currentAmmo <= 0)
        {
            //StartCoroutine(Reload());

            return;
        }

        
        if (Input.GetMouseButtonDown(0) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            AudioSource.PlayClipAtPoint(flybyAudio, transform.position, 0.6f);
            animator.SetTrigger("Shooting");
            ShootSkill();
        }

        if (currentAmmo > maxAmmo)
        {
            currentAmmo = maxAmmo;
        }

        for (int i = 0; i < rocksAmmo.Length; i++)
        {
            int leftAmmo = maxAmmo - currentAmmo;

            if (i < leftAmmo)
            {
                rocksAmmo[i].sprite = emptyRock;
            }
            else
            {
                rocksAmmo[i].sprite = rock;
            }
        }
    }

    //IEnumerator Reload()
    //{
    //    isReloading = true;
    //    Debug.Log("Reloading...");

    //    yield return new WaitForSeconds(reloadTime);

    //    Debug.Log("Reloaded...");
    //    currentAmmo = maxAmmo;
    //    isReloading = false;
    //}

    public void FullAmmoTrigger()
    {
        currentAmmo = maxAmmo;
    }

    private void ShootSkill()
    {
        currentAmmo--;

        RaycastHit hit;
        Debug.DrawRay(tpsGun.transform.position, tpsGun.transform.forward * range, Color.red);

        if (Physics.Raycast(tpsGun.transform.position, tpsGun.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Vector3 hitpoint = hit.point;

            Vector3 gunposition = gun.transform.position;

            Vector3 direction = (hitpoint - gunposition).normalized;

            RaycastHit hit2;

            if (Physics.Raycast (gunposition, direction, out hit2, range))
            {
                Target target = hit2.transform.GetComponent<Target>();
                if (target != null && target.IsShootable)
                {
                    target.HitTarget(ShootTarget);                 
                }
                
                GameObject impactGo = Instantiate(impactEffect, hit2.point + hit2.normal * 0.0001f, Quaternion.LookRotation(hit2.normal));

                Destroy(impactGo, 2f);

                AudioSource.PlayClipAtPoint(impactAudio, hitpoint);

                Debug.DrawLine(gunposition, hit2.point, Color.blue);
            }
            direction = (hit.point - gun.position).normalized;
            Vector3 position = hit.point;
            aimTarget.transform.position = Vector3.Lerp(aimTarget.transform.position, position, ikSmoothness * Time.deltaTime);
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
