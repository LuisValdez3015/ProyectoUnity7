using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovimiento : MonoBehaviour
{
    [SerializeField] public float playerSpeed = 6f;

    [SerializeField] public float jumpHeight = 1.0f;

    [HideInInspector] [SerializeField] Transform groundRaycastOriginCenter;

    [HideInInspector] [SerializeField] Transform groundRaycastOriginFront;

    [HideInInspector] [SerializeField] Transform groundRaycastOriginBack;

    [HideInInspector] [SerializeField] Transform groundRaycastOriginLeft;

    [HideInInspector] [SerializeField] Transform groundRaycastOriginRight;

    [HideInInspector] [SerializeField] Transform groundRaycastFrontLeft;

    [HideInInspector] [SerializeField] Transform groundRaycastFrontRight;

    [HideInInspector] [SerializeField] Transform groundRaycastBackLeft;

    [HideInInspector] [SerializeField] Transform groundRaycastBackRight;

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

    Animator animator;

    [HideInInspector] [SerializeField] GameObject raycastJumpOriginCenter;

    [HideInInspector] [SerializeField] GameObject raycastJumpOriginFront;

    [HideInInspector] [SerializeField] GameObject raycastJumpOriginBack;

    [HideInInspector] [SerializeField] GameObject raycastJumpOriginLeft;

    [HideInInspector] [SerializeField] GameObject raycastJumpOriginRight;

    [HideInInspector] [SerializeField] GameObject raycastJumpOriginFrontLeft;

    [HideInInspector] [SerializeField] GameObject raycastJumpOriginFrontRight;

    [HideInInspector] [SerializeField] GameObject raycastJumpOriginBackLeft;

    [HideInInspector] [SerializeField] GameObject raycastJumpOriginBackRight;

    [SerializeField] float groundDistance;

    public GameObject footstep;

    private int jumpRayCount;

    //[SerializeField] private float rotationSpeed = 5f;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        animator = GetComponentInChildren<Animator>();
    }
    private void Start()
    {
        cameraTransform = Camera.main.transform;
        //StopFootsteps();
    }

    private void Update()
    {        
        groundedPlayer = CheckGround();
        DoGravity();
        controller.Move(playerVelocity * Time.deltaTime);

        if (groundedPlayer && playerVelocity.y > 0)
        {
            animator.SetTrigger("Jump");
            animator.ResetTrigger("GroundedJump");
            //StopFootsteps();
        }

        //if (!groundedPlayer && playerVelocity.y > 0)
        //{
        //    StopFootsteps();
        //}



        if (!groundedPlayer && playerVelocity.y < 0)
        {
            animator.SetFloat("YVelocity", playerVelocity.y);
            RaycastHit hit;
            //StopFootsteps();

            Debug.DrawRay(raycastJumpOriginCenter.transform.position, Vector3.down * groundDistance, Color.magenta);

            Debug.DrawRay(raycastJumpOriginFront.transform.position, Vector3.down * groundDistance, Color.magenta);

            Debug.DrawRay(raycastJumpOriginBack.transform.position, Vector3.down * groundDistance, Color.magenta);

            Debug.DrawRay(raycastJumpOriginLeft.transform.position, Vector3.down * groundDistance, Color.magenta);

            Debug.DrawRay(raycastJumpOriginRight.transform.position, Vector3.down * groundDistance, Color.magenta);

            Debug.DrawRay(raycastJumpOriginFrontLeft.transform.position, Vector3.down * groundDistance, Color.magenta);

            Debug.DrawRay(raycastJumpOriginFrontRight.transform.position, Vector3.down * groundDistance, Color.magenta);

            Debug.DrawRay(raycastJumpOriginBackLeft.transform.position, Vector3.down * groundDistance, Color.magenta);

            Debug.DrawRay(raycastJumpOriginBackRight.transform.position, Vector3.down * groundDistance, Color.magenta);

            if (Physics.Raycast(raycastJumpOriginCenter.transform.position, Vector3.down, out hit, groundDistance))
            {
                jumpRayCount++;
            }

            if (Physics.Raycast(raycastJumpOriginFront.transform.position, Vector3.down, out hit, groundDistance))
            {
                jumpRayCount++;
            }

            if (Physics.Raycast(raycastJumpOriginBack.transform.position, Vector3.down, out hit, groundDistance))
            {
                jumpRayCount++;
            }

            if (Physics.Raycast(raycastJumpOriginLeft.transform.position, Vector3.down, out hit, groundDistance))
            {
                jumpRayCount++;
            }

            if (Physics.Raycast(raycastJumpOriginRight.transform.position, Vector3.down, out hit, groundDistance))
            {
                jumpRayCount++;
            }

            if (Physics.Raycast(raycastJumpOriginFrontLeft.transform.position, Vector3.down, out hit, groundDistance))
            {
                jumpRayCount++;
            }

            if (Physics.Raycast(raycastJumpOriginFrontRight.transform.position, Vector3.down, out hit, groundDistance))
            {
                jumpRayCount++;
            }

            if (Physics.Raycast(raycastJumpOriginBackLeft.transform.position, Vector3.down, out hit, groundDistance))
            {
                jumpRayCount++;
            }

            if (Physics.Raycast(raycastJumpOriginBackRight.transform.position, Vector3.down, out hit, groundDistance))
            {
                jumpRayCount++;
            }

            if (jumpRayCount > 0)
            {
                animator.SetTrigger("GroundedJump");
                animator.ResetTrigger("Jump");
            }
        }
    }

    public void LateUpdate()
    {
        if (animator.GetBool("IsWalking") && groundedPlayer)
        {
            Footsteps();
        }
        else
        {
            StopFootsteps();
        }
        
    }

    public void Move(Vector3 direction)
    {
        if (direction.magnitude >= 0.1f)
        {
            animator.SetBool("IsWalking", true);
            
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            var currentSpeed = playerController.PlayerSkill.IsBeingUse ? playerSpeedWhenUsingSkill : playerSpeed;
            controller.Move(moveDir.normalized * currentSpeed * Time.deltaTime);

            //Footsteps();
            //animator.SetBool("IsWalking", false);

            //animator.SetBool("IsMouthFull", true);

        }
        else
        {
            animator.SetBool("IsWalking", false);
            //StopFootsteps();
        }
        
    }

    public void Stop()
    {
        animator.SetBool("IsWalking", false);
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
        //StopFootsteps();
    }

    public bool CheckGround()
    {
        RaycastHit hit;
        Debug.DrawRay(groundRaycastOriginCenter.position, Vector3.down * groundRaycastDistance, Color.red);

        Debug.DrawRay(groundRaycastOriginFront.position, Vector3.down * groundRaycastDistance, Color.red);

        Debug.DrawRay(groundRaycastOriginBack.position, Vector3.down * groundRaycastDistance, Color.red);

        Debug.DrawRay(groundRaycastOriginLeft.position, Vector3.down * groundRaycastDistance, Color.red);

        Debug.DrawRay(groundRaycastOriginRight.position, Vector3.down * groundRaycastDistance, Color.red);

        Debug.DrawRay(groundRaycastFrontLeft.position, Vector3.down * groundRaycastDistance, Color.red);

        Debug.DrawRay(groundRaycastFrontRight.position, Vector3.down * groundRaycastDistance, Color.red);

        Debug.DrawRay(groundRaycastBackLeft.position, Vector3.down * groundRaycastDistance, Color.red);

        Debug.DrawRay(groundRaycastBackRight.position, Vector3.down * groundRaycastDistance, Color.red);

        if (Physics.Raycast(groundRaycastOriginCenter.position, Vector3.down, out hit, groundRaycastDistance))
        {
            return true;
        }

        if (Physics.Raycast(groundRaycastOriginFront.position, Vector3.down, out hit, groundRaycastDistance))
        {
            return true;
        }

        if (Physics.Raycast(groundRaycastOriginBack.position, Vector3.down, out hit, groundRaycastDistance))
        {
            return true;
        }

        if (Physics.Raycast(groundRaycastOriginLeft.position, Vector3.down, out hit, groundRaycastDistance))
        {
            return true;
        }

        if (Physics.Raycast(groundRaycastOriginRight.position, Vector3.down, out hit, groundRaycastDistance))
        {
            return true;
        }

        if (Physics.Raycast(groundRaycastFrontLeft.position, Vector3.down, out hit, groundRaycastDistance))
        {
            return true;
        }

        if (Physics.Raycast(groundRaycastFrontRight.position, Vector3.down, out hit, groundRaycastDistance))
        {
            return true;
        }

        if (Physics.Raycast(groundRaycastBackLeft.position, Vector3.down, out hit, groundRaycastDistance))
        {
            return true;
        }

        if (Physics.Raycast(groundRaycastBackRight.position, Vector3.down, out hit, groundRaycastDistance))
        {
            return true;
        }
        return false;
    }

    public void Bounce(float force)
    {
        playerVelocity.y = Mathf.Sqrt(force * -3f * (gravity * gravityScale));
    }

    public void Footsteps()
    {
        footstep.SetActive(true);
    }

    public void StopFootsteps()
    {
        footstep.SetActive(false);
    }
}