using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;

//[RequireComponent(typeof(CharacterController), typeof(PlayerInput))]
public class ShootSkill : MonoBehaviour
{
    //[SerializeField] private GameObject bulletPrefab;

    //[SerializeField] private Transform barrelTransform;

    //[SerializeField] private Transform bulletParent;

    //[SerializeField] private float bulletHitMissDistance = 25f;

    private CharacterController controller;
    //private PlayerInput playerInput;

    //private InputAction shootAction;

    public Transform camPos;

    public float raycastDistance = 100f;
    public LayerMask raycastMask;
    Camera cachedCamera;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        //playerInput = GetComponent<PlayerInput>();
        camPos = Camera.main.transform;
        cachedCamera = Camera.main;
        //shootAction = playerInput.actions["Shoot"];
    }
    //private void OnEnable()
    //{
    //    shootAction.performed += _ => ShootGun();
    //}

    //private void OnDisable()
    //{
    //    shootAction.performed -= _ => ShootGun();
    //}

    private void ShootGun()
    {
        //RaycastHit hit;
        //GameObject bullet = GameObject.Instantiate(bulletPrefab, barrelTransform.position, Quaternion.identity, bulletParent);

        //BulletController bulletController = bullet.GetComponent<BulletController>();
        //if (Physics.Raycast(camPos.position, camPos.forward, out hit, Mathf.Infinity))
        //{
        //    bulletController.target = hit.point;
        //    bulletController.hit = true;
        //}

        //else
        //{
        //    bulletController.target = camPos.position + camPos.forward * bulletHitMissDistance;
        //    bulletController.hit = false;
        //}

        Ray ray = cachedCamera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, raycastDistance, raycastMask))
        {
            Vector3 hitPoint = hit.point;
            hitPoint.y = transform.position.y;
            transform.LookAt(hit.point);
        }
        Debug.DrawRay(ray.origin, ray.direction * raycastDistance, Color.red);
    }
}