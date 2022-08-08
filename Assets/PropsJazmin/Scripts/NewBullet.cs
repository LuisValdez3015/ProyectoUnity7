using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NewBullet : MonoBehaviour
{
    float moveSpeed = 20f;

    Rigidbody rb;
    
    GameObject target;

    Vector3 moveDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        var targets = GameObject.FindGameObjectsWithTag("Player").ToList();
        GameObject nearestTarget = null;
        float nearestDistance = 999f;
        foreach (var target in targets)
        {
            var distance = Vector3.Distance(target.transform.position, transform.position);
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestTarget = target;
            }
        }
        if(nearestTarget == null)
        {
            return;
        }
        target = nearestTarget;
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector3(moveDirection.x, moveDirection.y, moveDirection.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        CharacterController danio = GetComponent<CharacterController>();

        if(danio)
        {
            Destroy(this.gameObject);
        }
    }


}
