using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class SwitchVCamPULL : MonoBehaviour
{
    //[SerializeField] private PlayerInput playerInput;
    [SerializeField] private int priorityBoostAmount = 10;
    //[SerializeField] private Canvas aimCanvas;

    [SerializeField] private GameObject aimCanvas;

    //private InputAction aimAction;

    private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private bool boosted = false;

    private Transform cameraTransform;

    [SerializeField] private float rotationSpeed = 10f;

    public GameObject Player;

    [SerializeField] Pull pullMecanic;

    private void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        Cursor.lockState = CursorLockMode.Locked;
        cameraTransform = Camera.main.transform;
        //aimAction = playerInput.actions["Aim"];
        //aimCanvas.enabled = false;
    }

    public void Update()
    {
        if (virtualCamera != null)
        {
            bool aiming = Input.GetMouseButton(1);
            if (aiming)
            {
                if (!boosted)
                {
                    virtualCamera.Priority += priorityBoostAmount;
                    boosted = true;

                    //Player.GetComponent<PlayerMovimiento>();
                    //Esto supuestamente es para que el player rote junto a la camara Aim
                    Quaternion targetRotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);
                    transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                }
            }
            else if (boosted)
            {
                virtualCamera.Priority -= priorityBoostAmount;
                boosted = false;
            }

            pullMecanic.enabled = aiming;

        }
        if (aimCanvas != null)
        {
            aimCanvas.SetActive(boosted);
        }                 
    }

    //private void OnEnable()
    //{
    //    aimAction.performed += _ => StartAim();
    //    aimAction.canceled += _ => CancelAim();
    //}

    //private void OnDisable()
    //{
    //    aimAction.performed -= _ => StartAim();
    //    aimAction.canceled -= _ => CancelAim();
    //}

    //private void StartAim()
    //{
    //    virtualCamera.Priority += priorityBoostAmount;
    //    aimCanvas.enabled = true;
    //}

    //private void CancelAim()
    //{
    //    virtualCamera.Priority -= priorityBoostAmount;
    //    aimCanvas.enabled = false;
    //}

}
