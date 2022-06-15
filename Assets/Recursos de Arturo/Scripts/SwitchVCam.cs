using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using System;
using UnityEngine.Animations.Rigging;

public class SwitchVCam : MonoBehaviour
{
    //[SerializeField] private PlayerInput playerInput;
    [SerializeField] private int priorityBoostAmount = 10;
    //[SerializeField] private Canvas aimCanvas;

    [SerializeField] private GameObject aimCanvas;

    //private InputAction aimAction;

    private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private bool boosted = false;

    private Transform cameraTransform;

    //[SerializeField] private float rotationSpeed = 10f;

    //public GameObject Player;

    [SerializeField] GunSkill gunSkill;

    public event Action aimCamActivated;

    private PlayerController currentPlayer;

    [SerializeField] private Transform character;

    //[SerializeField] private Rig aimRig;

    private void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        //Cursor.lockState = CursorLockMode.Locked;
        cameraTransform = Camera.main.transform;
        //aimAction = playerInput.actions["Aim"];
        //aimCanvas.enabled = false;
    }

    public void Update()
    {
        if (virtualCamera != null)
        {
            if (Input.GetMouseButtonDown(1))
            {
                aimCamActivated?.Invoke();
            }

            bool aiming = Input.GetMouseButton(1);

            currentPlayer.Animator.SetBool("IsAiming", aiming);
           
            if (aiming)
            {
                //PlayerController player = character.GetComponent<PlayerController>();
                currentPlayer.transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
                currentPlayer.CharacterRig.weight = .5f;
                //transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                //aimRig.weight = 0.5f;

                if (!boosted)
                {
                    virtualCamera.Priority += priorityBoostAmount;
                    boosted = true;
                    //aimRig.weight = 0f;
                }
            }
            else if (boosted)
            {
                virtualCamera.Priority -= priorityBoostAmount;
                boosted = false;
                currentPlayer.CharacterRig.weight = 0f;
            }

            gunSkill.enabled = aiming;
            
        }
        if (aimCanvas != null)
        {
            aimCanvas.SetActive(boosted);
            currentPlayer.CharacterAimCanvas.gameObject.SetActive(boosted);
        }                 
    }

    public void SetCurrentPlayer(PlayerController player)
    {
        currentPlayer = player;
    }
}
