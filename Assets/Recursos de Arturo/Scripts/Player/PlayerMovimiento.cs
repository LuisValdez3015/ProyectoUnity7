using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovimiento : MonoBehaviour
{
    [SerializeField] public float playerSpeed = 6f;

    [SerializeField] public float jumpHeight = 1.0f;

    private float gravity = -9.81f;

    private float turnSmoothTime = 0.1f;

    private float gravityScale = 1;

    private Vector3 playerVelocity;

    public bool groundedPlayer;

    private float turnSmoothVelocity;

    public CharacterController controller;
    public Transform cam;

    private Transform camAim;
    private Transform cameraTransform;

    //[SerializeField] private float rotationSpeed = 5f;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        DoGravity();
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void Move(Vector3 direction)
    {
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * playerSpeed * Time.deltaTime);
        }
    }

    public void DoGravity()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        playerVelocity.y += gravity * gravityScale * 2f * Time.deltaTime;
        //controller.Move(playerVelocity * Time.deltaTime);
    }


    public void Jump()
    {
        if (!groundedPlayer) return;
               
        playerVelocity.y = Mathf.Sqrt(jumpHeight * -3f * (gravity * gravityScale));      
    }

    public void Bounce(float force)
    {
        playerVelocity.y = Mathf.Sqrt(force * -3f * (gravity * gravityScale));
    }

    //private void Update()
    //{
    //    float horizontal = Input.GetAxisRaw("Horizontal");
    //    float vertical = Input.GetAxisRaw("Vertical");
    //    Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

    //    if (direction.magnitude >= 0.1f)
    //    {
    //        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
    //        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
    //        transform.rotation = Quaternion.Euler(0f, angle, 0f);

    //        Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
    //        controller.Move(moveDir.normalized * playerSpeed * Time.deltaTime);
    //    }

    //    groundedPlayer = controller.isGrounded;
    //    if (groundedPlayer && playerVelocity.y < 0)
    //    {
    //        playerVelocity.y = 0f;
    //    }
    //    playerVelocity.y += gravity * gravityScale * Time.deltaTime;

    //    // Changes the height position of the player..
    //    if (Input.GetButtonDown("Jump") && groundedPlayer)
    //    {
    //        playerVelocity.y = Mathf.Sqrt(jumpHeight * -3f * (gravity * gravityScale));
    //    }

    //    playerVelocity.y += gravity * Time.deltaTime;
    //    controller.Move(playerVelocity * Time.deltaTime);

    //    //Esto es para que rote el player
    //    //Quaternion targetRotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);
    //    //transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    //}
}