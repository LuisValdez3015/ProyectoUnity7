using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController), typeof(PlayerInput))]
public class ThirthpersonMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 2.0f;

    [SerializeField] private float jumpHeight = 1.0f;

    [SerializeField] private float gravityValue = -9.81f;

    [SerializeField] private float turnSmoothTime = 0.1f;

 

    private CharacterController controller;
    private PlayerInput playerInput;

    private Vector3 playerVelocity;

    private bool groundedPlayer;
    private float turnSmoothVelocity;

    private InputAction moveAction;
    private InputAction jumpAction;
    

    public Transform camPos;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        camPos = Camera.main.transform;
        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];
       

        Cursor.lockState = CursorLockMode.Locked;
    }

    

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        //Vector2 input = moveAction.ReadValue<Vector2>();
        //Vector3 move = new Vector3(input.x, 0, input.y);
        //controller.Move(move * Time.deltaTime * playerSpeed);

        Vector2 input = moveAction.ReadValue<Vector2>();
        Vector3 direction = new Vector3(input.x, 0f, input.y).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camPos.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            //controller.Move(moveDir.normalized * playerSpeed * Time.deltaTime);
            controller.Move(moveDir.normalized * Time.deltaTime * playerSpeed);
        }

        // Changes the height position of the player..
        if (jumpAction.triggered && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
