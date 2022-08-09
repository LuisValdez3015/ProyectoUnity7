using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resortera : MonoBehaviour
{
    public GameObject resortera;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().isCharacterSkillEnabled = true;
            resortera.gameObject.SetActive(true);
            Destroy(gameObject);
        }
    }
}
