using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    [SerializeField] int reachRange = 100;
    [SerializeField] GameObject Lever;


    public void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            CheckHitObj();
        }
    }

    public void CheckHitObj()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, reachRange))
        {
            Lever.transform.Rotate(new Vector3(0, 0, 0), Space.World);
        }
    }
}
