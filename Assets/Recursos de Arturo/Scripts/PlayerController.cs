using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovimiento playerMovimiento;
   
    private Vector3 spawnPoint;
    //private Vector3 newCheckPoint;

    private void Start()
    {
        SetNewSpawnPoint(transform.position);
        playerMovimiento = GetComponent<PlayerMovimiento>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        playerMovimiento.Move(direction);

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump"))
        {
            playerMovimiento.Jump();
        }        

        //Esto es para que rote el player
        //Quaternion targetRotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);
        //transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
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

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        spawnPoint = this.gameObject.transform.position;
    //        _gm.lastCheckRotation = _playerPos.gameObject.transform.rotation;
    //    }
    //}
}
