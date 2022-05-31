using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class LeverRotate : MonoBehaviour
{
    [SerializeField] int reachRange = 50;

    [SerializeField] GameObject[] colors;

    public static event Action<string, int> Rotated = delegate { };

    private bool coroutineAllowed;

    private int numberShown;

    private void Start()
    {
        coroutineAllowed = true;
        numberShown = 0;

        RotateLever(0);
    }

    private void OnMouseDown()
    {
        if (coroutineAllowed)
        {
            RotateLever(1);
        }
    }

    private void RotateLever(int direction)
    {
        colors[numberShown].SetActive(false);

        coroutineAllowed = true;
        numberShown += direction;

        if (numberShown > 2)
        {
            numberShown = 0;
        }

        var Rotation = new Vector3(20 * numberShown, 0f, 0f);
        transform.DORotate(Rotation, .3f);

        colors[numberShown].SetActive(true);

        Rotated(name, numberShown);
    }
}
