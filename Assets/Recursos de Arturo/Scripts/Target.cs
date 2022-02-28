using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] bool isShootable;

    public bool IsShootable => isShootable;

    public void HitTarget (float amount)
    {
        Destroy(gameObject);
    }
}
