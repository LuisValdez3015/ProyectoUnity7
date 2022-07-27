using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePush : MonoBehaviour
{
    public string pushableTag;
    [SerializeField] private float forceMagnitude;

    Animator anim;

    bool isPushing;

    float timeOfLastPushing;
    float pushingResetTime = .1f;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        anim.SetBool("Pushing", isPushing);

        if (Time.time > timeOfLastPushing + pushingResetTime)
            isPushing = false;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rigidbody = hit.collider.attachedRigidbody;

        if(rigidbody == null)
        {
            return;
        }

        if(!hit.gameObject.CompareTag(pushableTag))
        {
            return;
        }

        if(Input.GetKey(KeyCode.E))
        {
            Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
            forceDirection.y = 0;
            forceDirection.Normalize();
            rigidbody.AddForceAtPosition(forceDirection * forceMagnitude, transform.position, ForceMode.Impulse);
            //rigidbody.velocity = forceDirection * forceMagnitude;
            //anim.SetTrigger("Push");
            isPushing = true;
            timeOfLastPushing = Time.time;
        }
        else
        {
            isPushing = false;
            //rigidbody.velocity = Vector3.zero;
        }

    }
}
