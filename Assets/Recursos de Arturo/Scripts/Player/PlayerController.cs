using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerController : MonoBehaviour
{
    public List<int> Keys = new List<int>();

    [SerializeField] public int playerId;

    private PlayerMovimiento playerMovimiento;

    private PlayerSkill playerSkill;
   
    private Vector3 spawnPoint;

    [SerializeField] Transform cameraLookAt;

    public Transform CameraLookAt => cameraLookAt;

    [SerializeField] AudioClip aimAudio;

    public AudioClip AimAudio => aimAudio;
    public PlayerSkill PlayerSkill => playerSkill;
    //private GameObject checkPoint;
    //private Vector3 newCheckPoint;


    //Cambios nuevos
    [SerializeField] Canvas characterAimCanvas;

    [SerializeField] Canvas characterNormalCanvas;

    public Canvas CharacterAimCanvas => characterAimCanvas;

    public bool IsInControl {get; private set;}

    public Animator Animator { get; private set; }

    [SerializeField] Rig characterRig;

    public Rig CharacterRig => characterRig;

    [SerializeField] Transform friend = default;

    private void Awake()
    {
        playerSkill = GetComponentInChildren<PlayerSkill>();
        playerMovimiento = GetComponent<PlayerMovimiento>();
        Animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        SetNewSpawnPoint(transform.position);
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        playerMovimiento.Move(direction);

        if (Input.GetButtonDown("Jump"))
        {
            playerMovimiento.Jump();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            LookAtFriend();
        }

        //Esto es para que rote el player
        //Quaternion targetRotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);
        //transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    public void LookAtFriend()
    {
        transform.LookAt(friend);

        Animator.SetTrigger("Hello");
    }

    public void Kill()
    {
        Debug.Log("Kill");
        gameObject.SetActive(false);
        FindObjectOfType<GameManager>().RespawnCharacter(this);
    }

    public void Respawn()
    {
        transform.position = spawnPoint;
        gameObject.SetActive(true);
    }

    public void SetNewSpawnPoint(Vector3 position)
    {
        spawnPoint = position;           
    }

    public void GiveControl()
    {
        this.enabled = true;
        playerSkill.enabled = true;
        playerSkill.SetActive(true);
        characterAimCanvas.enabled = true;
        characterNormalCanvas.enabled = true;
        IsInControl = true;
    }

    public void LoseControl()
    {
        this.enabled = false;
        playerSkill.enabled = false;
        playerSkill.SetActive(false);
        characterAimCanvas.enabled = false;
        characterNormalCanvas.enabled = false;
        IsInControl = false;
        playerMovimiento.Stop();
    }


    public void Addkey(int id)
    {
        Keys.Add(id);
    }

    public bool HasKey(int id)
    {
        return Keys.Contains(id);
    }

    public bool ConsumeKey(int id)
    {
        if (!HasKey(id))
            return false;
        Keys.Remove(id);
        return true;
    }
}
