using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkillsOnOff : MonoBehaviour
{
    public GameObject weaver;
    public GameObject toolBag;
    public SwitchVCam switchVCam;

    public void Start()
    {
        //GunSkill gunSkill = GetComponentInChildren<GunSkill>();
        //BiteDestroy biteDestroy = GetComponent<BiteDestroy>();

        Scene currentScene = SceneManager.GetActiveScene();

        int buildIndex = currentScene.buildIndex;

        if (buildIndex == 2)
        {
            weaver.GetComponent<BiteDestroy>().enabled = false;
            weaver.GetComponent<PlayerController>().isCharacterSkillEnabled = true;
            toolBag.GetComponent<PlayerController>().isCharacterSkillEnabled = false;
            switchVCam.gunSkill.enabled = false;
        }

        if (buildIndex == 3)
        {
            weaver.GetComponent<BiteDestroy>().enabled = true;
            weaver.GetComponent<PlayerController>().isCharacterSkillEnabled = true;
            toolBag.GetComponent<PlayerController>().isCharacterSkillEnabled = false;
            switchVCam.gunSkill.enabled = false;
        }

        if (buildIndex == 4)
        {
            weaver.GetComponent<BiteDestroy>().enabled = true;
            weaver.GetComponent<PlayerController>().isCharacterSkillEnabled = true;
            toolBag.GetComponent<PlayerController>().isCharacterSkillEnabled = true;
            switchVCam.gunSkill.enabled = true;
        }
    }
}
