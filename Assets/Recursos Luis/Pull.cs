using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pull : PlayerSkill
{
    [Tooltip("Es a donde va a ir el objeto que jale")]
    public Transform hand;

    [Tooltip("el tag que llevan todo lo que se pueda jalar")]
    public string pullableTag;

    [Tooltip("la fuerza de jale")]
    public float modifier = 1.0f;

    [Tooltip("direccion")]
    Vector3 pullForce;

    [Tooltip("aqui no va nada esto in game se pone segun lo que estes agarrando")]
    public Transform heldObject;

    [Tooltip("la distancia")]
    public float positionDistanceThreshold = 1;

    [Tooltip("velocidad")]
    public float velocityDistanceThreshold;

    [Tooltip("Velocidad maxima")]
    public float maxVelocity;

    [Tooltip("velocidad con la que se suelta")]
    public float throwVelocity;

    [SerializeField] private Camera pullCamera;

    [System.Obsolete]
    void Update()
    {
        if (!isActive)
        {
            return;
        }


        if (Input.GetKey(KeyCode.J))
            Screen.lockCursor = false;
        else
            Screen.lockCursor = true;

        RaycastHit hit;
        Debug.DrawRay(pullCamera.transform.position, pullCamera.transform.forward * Mathf.Infinity, Color.blue);
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(pullCamera.transform.position, pullCamera.transform.forward, out hit, Mathf.Infinity))
            {
                if (hit.transform.tag.Equals(pullableTag))
                {
                    StartCoroutine(PullObject(hit.transform));
                }
            }
            
        }

        
        if (Input.GetKey(KeyCode.E))
        {
            if (heldObject != null)
            {
                heldObject.transform.parent = null;
                heldObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                heldObject.GetComponent<Rigidbody>().velocity = transform.forward * throwVelocity;
                heldObject = null;
            }
        }
    }

    IEnumerator PullObject(Transform t)
    {
        Rigidbody r = t.GetComponent<Rigidbody>();
        while (true)
        {

            // right-clicks, stop pulling
            if (Input.GetKey(KeyCode.E))
            {
                break;
            }
            float distanceToHand = Vector3.Distance(t.position, hand.position);
            
            if (distanceToHand < positionDistanceThreshold)
            {
                t.position = hand.position;
                t.parent = hand;
                r.constraints = RigidbodyConstraints.FreezePosition;
                heldObject = t;
                break;
            }

            //  Calculate the pull direction vector
            Vector3 pullDirection = hand.position - t.position;

            //  Normalize it and multiply by the force modifier
            pullForce = pullDirection.normalized * modifier;

           
            if (r.velocity.magnitude < maxVelocity && distanceToHand > velocityDistanceThreshold)
            {

                
                r.AddForce(pullForce, ForceMode.Force);
            }
            else
            {

              
                r.velocity = pullDirection.normalized * maxVelocity;
            }

            yield return null;
        }
    }
   
}
