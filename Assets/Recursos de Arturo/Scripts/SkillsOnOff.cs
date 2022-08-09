using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkillsOnOff : MonoBehaviour
{
    public GameObject weaver;
    public GameObject toolBag;

    public void Start()
    {
        //GunSkill gunSkill = GetComponentInChildren<GunSkill>();
        //BiteDestroy biteDestroy = GetComponent<BiteDestroy>();

        Scene currentScene = SceneManager.GetActiveScene();

        int buildIndex = currentScene.buildIndex;

        if (buildIndex == 2)
        {
            weaver.GetComponent<BiteDestroy>().enabled = false;
            toolBag.gameObject.GetComponent<SwitchVCam>().gunSkill.enabled = false;
        }

        if (buildIndex == 3)
        {
            weaver.GetComponent<BiteDestroy>().enabled = true;
            toolBag.gameObject.GetComponent<SwitchVCam>().gunSkill.enabled = false;
        }

        if (buildIndex == 4)
        {
            weaver.GetComponent<BiteDestroy>().enabled = true;
            toolBag.gameObject.GetComponent<SwitchVCam>().gunSkill.enabled = false;
        }
    }

    //public void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        toolBag.gameObject.GetComponent<SwitchVCam>().gunSkill.enabled = true;
    //    }
    //}
}
