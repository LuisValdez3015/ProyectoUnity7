using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirthpersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    //[SerializeField] private Camera mainCamera;
    //public float raycastDistance = 1f;
    //public LayerMask raycastMask;
    //Vector3 input;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;

    float turnSmoothVelocity;
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

           
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        //input.x = horizontal;
        //input.z = vertical;

        //Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        //RaycastHit hit;
        //if (Physics.Raycast(ray, out hit, raycastDistance, raycastMask))
        //{
        //    Vector3 hitPoint = hit.point;
        //    hitPoint.y = transform.position.y;
        //    transform.LookAt(hit.point);
        //}
        //Debug.DrawRay(ray.origin, ray.direction * raycastDistance, Color.red);

        //bool isMoving = input.magnitude != 0;


        //Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        //if (Physics.Raycast(ray, out RaycastHit raycastHit))
        //{
        //    transform.position = raycastHit.point;
        //}
    }
}
