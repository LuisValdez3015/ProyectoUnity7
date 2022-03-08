using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CharacterSwap : MonoBehaviour
{
    [SerializeField] private Transform character;
    //[SerializeField] private Transform characterWeapon;
    [SerializeField] private List<Transform> possibleCharacters;
    [SerializeField] private int wichCharacter;
    [SerializeField] private CinemachineVirtualCamera camV;
    [SerializeField] private CinemachineVirtualCamera camAim;



    private void OnEnable()
    {
        camAim.GetComponent<SwitchVCam>().aimCamActivated += PlayCamAudio;
        camAim.GetComponent<SwitchVCam>().aimCamActivated += CharacterAimUI;
    }

    private void OnDisable()
    {
        camAim.GetComponent<SwitchVCam>().aimCamActivated -= PlayCamAudio;
        camAim.GetComponent<SwitchVCam>().aimCamActivated -= CharacterAimUI;

    }

    private void PlayCamAudio()
    {
        PlayerController player = character.GetComponent<PlayerController>();
        AudioSource.PlayClipAtPoint(player.AimAudio, Camera.main.transform.position);
    }

    private void CharacterAimUI()
    {
        PlayerController player = character.GetComponent<PlayerController>();        
    }

    void Start()
    {
        if (character == null && possibleCharacters.Count >= 1)
        {
            character = possibleCharacters[0];
        }
        Swap();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Swap();
        }
    }

    public void Swap()
    {
        if (wichCharacter == 0)
        {
            wichCharacter = possibleCharacters.Count - 1;
        }
        else
        {
            wichCharacter -= 1;
        }

        character = possibleCharacters[wichCharacter];
        character.GetComponent<PlayerController>().GiveControl();
        Transform lookAt = character.GetComponent<PlayerController>().CameraLookAt;

        for (int i = 0; i < possibleCharacters.Count; i++)
        {
            if (possibleCharacters[i] != character)
            {
                possibleCharacters[i].GetComponent<PlayerController>().LoseControl();
            }           
        }
        camV.LookAt = character;
        camV.Follow = character;

        camAim.LookAt = lookAt;
        camAim.Follow = lookAt;
    }
}
