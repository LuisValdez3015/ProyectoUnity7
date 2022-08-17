using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class LeverRotateLVL2 : MonoBehaviour
{
    [SerializeField] GameObject pressG;

    [SerializeField] GameObject[] colors;

    public static event Action<string, int> Rotated = delegate { };

    private bool coroutineAllowed;

    private int numberShown;

    public AudioSource sonidoSwitch;

    private void Start()
    {
        coroutineAllowed = true;
        numberShown = 0;

        RotateLever(0);
    }

    private void OnTriggerStay(Collider other)
    {
        //var playercontroller = other.gameObject.GetComponent<PlayerController>();
        //if (playercontroller == null)
        //{
        //    return;
        //}

        if (Input.GetKeyDown(KeyCode.G))
        {
            sonidoSwitch.Play();
            if (coroutineAllowed)
            {
                RotateLever(1);
                pressG.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        pressG.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        pressG.SetActive(false);
    }

    private void RotateLever(int direction)
    {
        colors[numberShown].SetActive(false);

        coroutineAllowed = true;
        numberShown += direction;

        if (numberShown > 1)
        {
            numberShown = 0;
        }

        var Rotation = new Vector3(10 * numberShown, -90f, 0f);
        transform.DORotate(Rotation, .3f);

        colors[numberShown].SetActive(true);

        Rotated(name, numberShown);
    }
}
