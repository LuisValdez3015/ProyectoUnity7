using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovimiento : MonoBehaviour
{
    [SerializeField] public float playerSpeed = 6f;

    [SerializeField] public float jumpHeight = 1.0f;

    [SerializeField] Transform groundRaycastOrigin;

    [SerializeField] float groundRaycastDistance;

    [SerializeField] private float playerSpeedWhenUsingSkill = 3;

    [SerializeField] private float playerJumpWhenUsingSkill = 0.5f;

    private float gravity = -9.81f;

    private float turnSmoothTime = 0.1f;

    private float gravityScale = 1;

    private Vector3 playerVelocity;

    public bool groundedPlayer;

    private float turnSmoothVelocity;

    private PlayerController playerController;

    public CharacterController controller;
    public Transform cam;
    
    private Transform camAim;
    private Transform cameraTransform;

    Animator anim;

    //[SerializeField] private float rotationSpeed = 5f;


    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        anim = GetComponentInChildren<Animator>();
    }
    private void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        groundedPlayer = CheckGround();
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

            var currentSpeed = playerController.PlayerSkill.IsBeingUse ? playerSpeedWhenUsingSkill : playerSpeed;
            controller.Move(moveDir.normalized * currentSpeed * Time.deltaTime);
            anim.SetBool("IsWalking", true);

        }
        else
        {
            anim.SetBool("IsWalking", false);
        }
    }

    public void DoGravity()
    {

        if (controller.isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        playerVelocity.y += gravity * gravityScale * 2f * Time.deltaTime;
        //controller.Move(playerVelocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (!groundedPlayer) return;
        var currentJump = playerController.PlayerSkill.IsBeingUse ? playerJumpWhenUsingSkill : jumpHeight;
        playerVelocity.y = Mathf.Sqrt(currentJump * -3f * (gravity * gravityScale));      
    }

    public bool CheckGround()
    {
        RaycastHit hit;
        Debug.DrawRay(groundRaycastOrigin.position, Vector3.down * groundRaycastDistance, Color.red);

        if (Physics.Raycast(groundRaycastOrigin.position, Vector3.down, out hit, groundRaycastDistance))
        {
            return true;
        }
        return false;
    }

    public void Bounce(float force)
    {
        playerVelocity.y = Mathf.Sqrt(force * -3f * (gravity * gravityScale));
    }

   
}