using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Pull : PlayerSkill
{
    [SerializeField] GameObject pesao;

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

    private PlayerMovimiento playerMovimiento;

    public float originalScale;

    Animator animator;

    public ParticleSystem tornadoPull;

    [SerializeField] GameObject aimTarget;

    [SerializeField] float ikSmoothness = 10f;

    [SerializeField] private float fireRate = 5f;

    private float nextTimeToFire = 0f;

    private void Start()
    {
        playerMovimiento = GetComponent<PlayerMovimiento>();
        animator = GetComponentInChildren<Animator>();  
    }

    void Update()
    {
        if (!isActive)
        {
            return;
        }

        if (!Input.GetMouseButton(1))
        {
            return;
        }

        //if (Input.GetKey(KeyCode.J))
        //    Screen.lockCursor = false;
        //else
        //    Screen.lockCursor = true;

        RaycastHit hit;

        Debug.DrawRay(pullCamera.transform.position, pullCamera.transform.forward * Mathf.Infinity, Color.blue);
        if (heldObject == null && Physics.Raycast(pullCamera.transform.position, pullCamera.transform.forward, out hit, Mathf.Infinity))
        {           
            if (Input.GetMouseButtonDown(0) && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;

                tornadoPull.Play();

                animator.SetTrigger("Pulling");

                if (hit.transform.tag.Equals(pullableTag))
                {
                    StartCoroutine(PullObject(hit.transform));
                    //GameObject.Find("Player").GetComponent<Animator>().SetBool("IsWalking", false);
                }

            }
            Vector3 direction = (hit.point - hand.position).normalized;
            Vector3 position = hit.point; //= hand.position + direction;
            aimTarget.transform.position = Vector3.Lerp(aimTarget.transform.position, position, ikSmoothness * Time.deltaTime);
        }        

        if (Input.GetKey(KeyCode.R))
        {
            if (heldObject != null)
            {
                heldObject.GetComponent<Rigidbody>().mass = 1;
                IsBeingUse = false;

                pesao.SetActive(false);
                //animator.SetBool("IsWalkingPesao", false);

                heldObject.transform.parent = null;
                heldObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                heldObject.GetComponent<Rigidbody>().velocity = transform.forward * throwVelocity;
                heldObject.DOScale(originalScale, .2f);
                //heldObject.gameObject.SetActive(true);
                heldObject.GetComponent<Rigidbody>().useGravity = true;
                heldObject.GetComponent<Rigidbody>().isKinematic = false;
                heldObject = null;
            }
        }
    }

    public override void StopSkill()
    {
        IsBeingUse = false;

        if (!IsBeingUse)
            return;
        if (heldObject == null)
            return;
        Rigidbody r = heldObject.GetComponent<Rigidbody>();
    
        r.useGravity = true;
        r.isKinematic = false;
        r.mass = 1;
    }

    IEnumerator PullObject(Transform t)
    {
        Rigidbody r = t.GetComponent<Rigidbody>();
        r.useGravity = false;
        r.isKinematic = true;
        IsBeingUse = true;
        r.mass = 0;

        GetComponent<CharacterController>().enabled = false;

        while (true)
        {
            // right-clicks, stop pulling
            if (Input.GetKey(KeyCode.R))
            {

                IsBeingUse = false;
                r.useGravity = true;
                r.isKinematic = false;
                r.mass = 1;
                break;
            }
            float distanceToHand = Vector3.Distance(t.position, hand.position);

            //if (distanceToHand < positionDistanceThreshold)
            //{
            //    t.position = hand.position;
            //    t.parent = hand;
            //    r.constraints = RigidbodyConstraints.FreezePosition;
            //    heldObject = t;
            //    break;
            //}

            var colliders = Physics.OverlapSphere(hand.position, positionDistanceThreshold);

            bool isin = false;

            for (int i = 0; i < colliders.Length; i++)
            {
                if (t.Equals(colliders[i].transform))
                {
                    isin = true;

                    break;
                }
            }

            if (isin)
            {
                t.parent = null;
                originalScale = t.localScale.x;
                t.position = hand.position;
                t.parent = hand;
                r.constraints = RigidbodyConstraints.FreezePosition;
                heldObject = t;
                //heldObject.GetComponent<Collider>().enabled = false;

                pesao.SetActive(true);
                //animator.SetBool("IsWalkingPesao", true);

                GetComponent<CharacterController>().enabled = true;

                heldObject.DOScale(0f, 0.2f);
                //heldObject.gameObject.SetActive(false);
                
                break;
            }

            //  Calculate the pull direction vector
            Vector3 pullDirection = hand.position - t.position;

            //  Normalize it and multiply by the force modifier
            pullForce = pullDirection.normalized * modifier;

           
            //if (r.velocity.magnitude < maxVelocity && distanceToHand > velocityDistanceThreshold)
            //{

                
            //    r.AddForce(pullForce, ForceMode.Force);
            //}
            //else
            //{

              
            //    r.velocity = pullDirection.normalized * maxVelocity;
            //}

            r.MovePosition(Vector3.Lerp(t.position, hand.position, Time.deltaTime * 100f));          

            yield return null;
        }
    }
   
}
