using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePush : MonoBehaviour
{
    public string pushableTag;
    [SerializeField] private float forceMagnitude;

    Animator anim;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rigidbody = hit.collider.attachedRigidbody;

        if (rigidbody != null && Input.GetKeyDown(KeyCode.E))
        {
            if (hit.transform.tag.Equals(pushableTag))
            {
                Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
                forceDirection.y = 0;
                forceDirection.Normalize();

                rigidbody.AddForceAtPosition(forceDirection * forceMagnitude, transform.position, ForceMode.Impulse);
                //    anim.SetBool("Push", true);

                //}
                //else
                //{
                //    anim.SetBool("Push", false);
            }
        }

    }
}
