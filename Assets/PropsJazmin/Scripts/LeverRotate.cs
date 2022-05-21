using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeverRotate : MonoBehaviour
{
    public static event Action<string, int> Rotate = delegate { };

    private bool coroutineAllowed;

    private int numberShown;

    private void Start()
    {
        coroutineAllowed = true;
        numberShown = 1;
    }

    private void OnMouseDown()
    {
        if(coroutineAllowed)
        {
            StartCoroutine("RotateLever");
        }
    }

    private IEnumerator RotateLever()
    {
        coroutineAllowed = false;

        for(int i = 0; i <= 11; i++)
        {
            transform.Rotate(50f, 0f, 0f);
            yield return new WaitForSeconds(.01f);
        }

        coroutineAllowed = true;
        numberShown += 1;

        if(numberShown > 4)
        {
            numberShown = 0;
        }

        Rotate(name, numberShown);
    }
}
