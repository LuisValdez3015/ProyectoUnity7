using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    //[SerializeField] int reachRange = 100;

    //CodeLever codeLock;

    //public Transform toMove;

    //public Transform palanca;

    //public void Update()
    //{
    //    if(Input.GetMouseButtonDown(0))
    //    {
    //        Debug.Log("Pressed");

    //        CheckHitObj();



    //        //palanca.Rotate(new Vector3(50, 0, 0), Space.World);
    //        //for (int i = 0; i < 3; i++)
    //        //{
    //        //    toMove.Rotate(new Vector3(50, 0, 0), Space.World);
    //        //}
    //    }
    //}

    //public void CheckHitObj()
    //{
    //    RaycastHit hit;
    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    //    if(Physics.Raycast(ray, out hit, reachRange))
    //    {
    //        codeLock = hit.transform.gameObject.GetComponentInParent<CodeLever>();

    //        if(codeLock != null)
    //        {
    //            string value = hit.transform.name;
    //            codeLock.SetValue(value);
    //        }    
    //    }
    //}
}
