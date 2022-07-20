using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnimigosShoot : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    public GameObject bulletprefab;
    public Transform bulletOrigin;

    public float timeBetweenShoots;
    private float timeOfLastShoot;

    private void Update()
    {
        if (Time.time > timeOfLastShoot + timeBetweenShoots)
            shoot();
    }

    private void shoot()
    {
        GameObject bullet = Instantiate(bulletprefab, bulletOrigin.position, bulletOrigin.rotation);
        Destroy(bullet, 2f);

        timeOfLastShoot = Time.time;
    }
}
