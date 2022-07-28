using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnimigosFire : MonoBehaviour
{
    [SerializeField] GameObject bulletEnimigo;
    [SerializeField] Transform bulletOrigin;
    [SerializeField] GameObject target;

    [SerializeField] Animator anim;

    public float range = 5f;

    float fireRate;
    float nextFire;

    private void Start()
    {
        fireRate = 3f;
        nextFire = Time.time;
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);

        if (distance < range)
        {
            CheckTimeToFire();
            anim.SetBool("Attack", true);
        }
        else
        {
            anim.SetBool("Attack", false);
        }
    }

    void CheckTimeToFire()
    {
        if (Time.time > nextFire)
        {
            Instantiate(bulletEnimigo, bulletOrigin.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
