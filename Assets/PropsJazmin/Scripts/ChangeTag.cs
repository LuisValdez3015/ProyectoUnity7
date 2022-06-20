using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTag : MonoBehaviour
{

    public string newTag;

    private void Start()
    {
        gameObject.tag = "Pullable";
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Suelo")
        {
            gameObject.tag = newTag;
        }
    }

}
