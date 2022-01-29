using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiteDestroy : MonoBehaviour
{
    bool m_Started;
    [SerializeField] private LayerMask LayerMask = default;

    [SerializeField] private float punchRate = 5f;

    [SerializeField] Vector3 boxOffset;

    private float nextTimeToPunch = 0f;

    void Start()
    {
        //Use this to ensure that the Gizmos are being drawn when in Play Mode.
        m_Started = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Time.time >= nextTimeToPunch)
        {
            nextTimeToPunch = Time.time + 1f / punchRate;
            MyCollisions();
        }

    }

    void MyCollisions()
    {
        //Use the OverlapBox to detect if there are any other colliders within this box area.
        //Use the GameObject's centre, half the size (as a radius) and rotation. This creates an invisible box around your GameObject.
        Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position + transform.forward + boxOffset * 1, transform.localScale / 2, Quaternion.identity, LayerMask);
        int i = 0;
        //Check when there is a new collider coming into contact with the box
        while (i < hitColliders.Length)
        {
            Debug.Log("Estoy golpeando" + transform.name);
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
        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
        if (m_Started)
            //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
            Gizmos.DrawWireCube(gameObject.transform.position + transform.forward + boxOffset * 1, transform.localScale);
    }
}
