using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerController : MonoBehaviour
{
    public Material normalMaterials;

    public Material deathMaterials;

    public Renderer rend;

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

    public bool IsInControl { get; private set; }

    public Animator Animator { get; private set; }

    [SerializeField] Rig characterRig;

    public Rig CharacterRig => characterRig;

    [SerializeField] Transform fren = default;

    [SerializeField] private bool isWaving = false;

    public bool isCharacterSkillEnabled;

    public AudioSource characterMusic;

    private void Awake()
    {
        playerSkill = GetComponentInChildren<PlayerSkill>();
        playerMovimiento = GetComponent<PlayerMovimiento>();
        Animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        SetNewSpawnPoint(transform.position);
        rend = GetComponentInChildren<Renderer>();
        //rend.material.shader = Shader.Find("CutoffHeight");
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

        if (isWaving)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            StartCoroutine(PosponerSaludo());
        }

        //Esto es para que rote el player
        //Quaternion targetRotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);
        //transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    public void LookAtFriend()
    {
        transform.LookAt(new Vector3(fren.position.x, transform.position.y, fren.position.z));

        Animator.SetTrigger("Hello");
    }

    IEnumerator PosponerSaludo()
    {
        isWaving = true;

        LookAtFriend();

        yield return new WaitForSeconds(1.3f);

        //nextTimeToPunch = Time.time + 1f / punchRate; 

        isWaving = false;
    }

    public void Kill()
    {
        gameObject.SetActive(false);
        FindObjectOfType<GameManager>().RespawnCharacter(this);
    }

    public IEnumerator PosponerKill()
    {
        rend.sharedMaterial = deathMaterials;

        float alpha = 0;

        GetComponent<CharacterController>().enabled = false;
        //playerMovimiento.StopFootsteps();
        LoseControl();
        Animator.SetTrigger("DeathAnim");

        while (alpha < 1)
        {
            alpha += Time.deltaTime / 2f;
            rend.material.SetFloat("_CutoffHeight", alpha);
            yield return null;
        }       
        Kill();
    }

    public void Respawn()
    {
        rend.sharedMaterial = normalMaterials;
        transform.position = spawnPoint;
        playerSkill.StopSkill();
        GetComponent<CharacterController>().enabled = true;
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
        playerMovimiento.StopFootsteps();
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
