using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTrigger : MonoBehaviour
{
    [SerializeField] Animator anim;

    private void OnDestroy()
    {
        anim.SetTrigger("Tornilloo");
        anim.SetTrigger("Falling");
    }
}
