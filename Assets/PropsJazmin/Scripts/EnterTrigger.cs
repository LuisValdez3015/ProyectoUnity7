using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterTrigger : MonoBehaviour
{
    public Animator anim;

    [SerializeField] Image imgPlayerHUD;

    public void AnimacionLlave()
    {
        anim.SetTrigger("LlaveT");
    }

    private void OnTriggerEnter(Collider other)
    {
        imgPlayerHUD.gameObject.SetActive(false);

        if(other.gameObject.name == "Llave")
        {
            AnimacionLlave();
        }
    }
}
