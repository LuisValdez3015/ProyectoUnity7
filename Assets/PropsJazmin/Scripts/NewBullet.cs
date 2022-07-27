using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBullet : MonoBehaviour
{
    float moveSpeed = 20f;

    Rigidbody rb;

    GameObject target;

    Vector3 moveDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player");
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
