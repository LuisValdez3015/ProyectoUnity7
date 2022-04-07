using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class TextOnScreen : MonoBehaviour
{
    [SerializeField] GameObject textoOnScreen;

    private void Start()
    {
        textoOnScreen.SetActive(false);
        textoOnScreen.GetComponent<TextMeshProUGUI>().DOFade(0f, .1f);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            textoOnScreen.SetActive(true);
            textoOnScreen.GetComponent<TextMeshProUGUI>().DOFade(1f, 3f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            textoOnScreen.GetComponent<TextMeshProUGUI>().DOFade(0f, 3f);

            StartCoroutine(WaitForSec());
        }
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(3.5f);
        textoOnScreen.SetActive(false);
    }
}
