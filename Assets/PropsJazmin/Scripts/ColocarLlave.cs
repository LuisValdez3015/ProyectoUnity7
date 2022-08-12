using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColocarLlave : MonoBehaviour
{
    [SerializeField] public int id;
    [SerializeField] public int playerId;
    [SerializeField] private GameObject key;

    [SerializeField] Image imgPlayerHUD;

    [SerializeField] private GameObject pressG;

    [SerializeField] private Image imgNeedKey;

    [SerializeField] private GameObject desactivarColocarLlave;

    [SerializeField] private BoxCollider boxColliderRecogerLlave;
    [SerializeField] private BoxCollider boxColliderColocarLlave;

    public AudioSource colocarLlave;
    public AudioSource algoFaltante;
    
    public bool hasKey;

    private void OnTriggerExit(Collider other)
    {
        var playercontroller = other.gameObject.GetComponent<PlayerController>();
        if (playercontroller == null)
            return;

        imgNeedKey.gameObject.SetActive(false);

        pressG.gameObject.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        var playercontroller = other.gameObject.GetComponent<PlayerController>();
        if (playercontroller == null)
            return;

        if (playerId == playercontroller.playerId)
        {
            if (playercontroller.HasKey(id))
            {
                imgNeedKey.gameObject.SetActive(false);
                pressG.gameObject.SetActive(true);
                if (Input.GetKey(KeyCode.G))
                {
                    StartCoroutine(ActivarBoxCollider());
                    playercontroller.ConsumeKey(id);
                    key.gameObject.SetActive(true);
                    colocarLlave.Play();
                    hasKey = true;
                    pressG.gameObject.SetActive(false);
                    imgPlayerHUD.gameObject.SetActive(false);
                    boxColliderColocarLlave.enabled = false;
                }
            }
            else
            {
                imgNeedKey.gameObject.SetActive(true);
            }
        }
        else
        {
            return;
        }
    }

    public IEnumerator ActivarBoxCollider()
    {
        yield return new WaitForSeconds(2f);
        boxColliderRecogerLlave.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        var playercontroller = other.gameObject.GetComponent<PlayerController>();
        if (playercontroller == null)
            return;
        if (!playercontroller.HasKey(id))
        {
            algoFaltante.Play();
        }

    }

}
