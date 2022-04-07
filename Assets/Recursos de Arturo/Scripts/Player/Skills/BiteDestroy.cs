using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiteDestroy : MonoBehaviour
{
    bool m_Started;

    [SerializeField] private LayerMask LayerMask = default;

    [SerializeField] private float punchRate = 1f;

    [SerializeField] Transform origin;

    private float nextTimeToPunch = 0f;

    Animator animator;

    [SerializeField] private bool isBiting = false;

    private PlayerController playerController;

    //Agregue los isBiting como arreglo rapido para que la corutina no se reproduzca dos veces, mas no se si es la mejor solucion 

    void Start()
    {
        m_Started = true;
        animator = GetComponentInChildren<Animator>();
        playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        if (!playerController.IsInControl)
        {
            return;
        }

        if (isBiting)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.E) && Time.time >= nextTimeToPunch)
        {            
            StartCoroutine(PosponerMordida());
        }


    }

    IEnumerator PosponerMordida()
    {
        isBiting = true;

        animator.SetTrigger("Bite");

        yield return new WaitForSeconds(.3f);

        nextTimeToPunch = Time.time + 1f / punchRate;
        MyCollisions();

        isBiting = false;
    }

    void MyCollisions()
    {
        Debug.Log("Estoy mordiendo ");
        //Use the OverlapBox to detect if there are any other colliders within this box area.
        //Use the GameObject's centre, half the size (as a radius) and rotation. This creates an invisible box around your GameObject.
        Collider[] hitColliders = Physics.OverlapBox(origin.position, transform.localScale / 2, Quaternion.identity, LayerMask);
        int i = 0;
        //Check when there is a new collider coming into contact with the box
        while (i < hitColliders.Length)
        {
            
            Target target = hitColliders[i].gameObject.GetComponent<Target>();
            if (target != null)
            {
                target.HitTarget(1);
            }
            //Output all of the collider names
            Debug.Log("Hit : " + hitColliders[i].name + i);
            //Increase the number of Colliders in the array
            i++;
        }
    }

    //Muestra la forma, escala y color de mi overlapbox
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        if (m_Started)
        {
            Gizmos.DrawWireCube(origin.position, transform.localScale);
        }
    }
}
