using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;

public class CharacterSwap : MonoBehaviour
{
    [SerializeField] private Transform character;
    //[SerializeField] private Transform characterWeapon;
    [SerializeField] private List<Transform> possibleCharacters;
    [SerializeField] private int wichCharacter;
    [SerializeField] private CinemachineVirtualCamera camV;
    [SerializeField] private CinemachineVirtualCamera camAim;

    [SerializeField] private AudioSource characterBgMusic;

    private PlayerMovimiento playerMovimiento;
    /*[SerializeField] float fadeOut = 5f;*/ //Cosas nuevas
    /*[SerializeField] float fadeIn = 5f;*/ //Cosas nuevas

    private void OnEnable()
    {
        camAim.GetComponent<SwitchVCam>().aimCamActivated += PlayCamAudio;
        //camAim.GetComponent<SwitchVCam>().aimCamActivated += CharacterAimUI;
    }

    private void OnDisable()
    {
        camAim.GetComponent<SwitchVCam>().aimCamActivated -= PlayCamAudio;
        //camAim.GetComponent<SwitchVCam>().aimCamActivated -= CharacterAimUI;
    }

    private void PlayCamAudio()
    {
        PlayerController player = character.GetComponent<PlayerController>();
        AudioSource.PlayClipAtPoint(player.AimAudio, Camera.main.transform.position);
    }

    void Start()
    {
        if (character == null && possibleCharacters.Count >= 1)
        {
            character = possibleCharacters[0];
        }
        Swap();
        characterBgMusic.DOFade(.65f, 2.5f); //Cosas nuevas
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
                characterBgMusic.DOFade(0.0f, 2.5f); //Cosas Nuevas
            }           
        }
        camV.LookAt = character.GetChild(5);
        camV.Follow = character.GetChild(5);

        camAim.LookAt = lookAt;
        camAim.Follow = lookAt;

        characterBgMusic = character.GetComponent<PlayerController>().characterMusic; //Cosas nuevas
        characterBgMusic.DOFade(.65f, 2.5f); //Cosas Nuevas
        //character.GetComponent<PlayerMovimiento>().StopFootsteps();

        camAim.GetComponent<SwitchVCam>().SetCurrentPlayer(character.GetComponent<PlayerController>());
    }

    //public IEnumerator MusicFade()
    //{
    //    Swap();
    //    characterBgMusic.DOFade(0.0f, 2f);
    //    //characterBgMusic.DOFade, fadeIn del otro personaje //TODO
    //    yield return new WaitForSeconds(2f);

    //    characterBgMusic.DOFade(1.0f, 2f);

    //    yield return null;
    //}
}
