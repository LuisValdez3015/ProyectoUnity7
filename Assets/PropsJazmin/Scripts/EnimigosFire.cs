using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnimigosFire : MonoBehaviour
{
    [SerializeField] GameObject bulletEnimigo;
    [SerializeField] Transform bulletOrigin;
    [SerializeField] GameObject target;
    [SerializeField] Transform target2;

    [SerializeField] Animator anim;

    [SerializeField] float timeBetweenShoots;
    float timeOfLastShoot;

    public float range = 5f;

    private void Update()
    {
        transform.LookAt(target2);

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
        if(Time.time > timeOfLastShoot + timeBetweenShoots)
        {
            Instantiate(bulletEnimigo, bulletOrigin.position, Quaternion.identity);
            timeOfLastShoot = Time.time;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
