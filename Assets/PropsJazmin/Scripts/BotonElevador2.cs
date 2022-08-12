using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BotonElevador2 : MonoBehaviour
{
    [SerializeField] GameObject verde2;

    [SerializeField] GameObject pressG;

    public Animator botonClick;
    public Animator puertaCerrar;

    public Image black;
    public Animator anim;

    [SerializeField] int nextLevelIndex; //Es el indice en el build settings
    [SerializeField] int savedLevelIndex;

    public AudioSource subennivel;

    public void OnTriggerStay(Collider other)
    {
        pressG.SetActive(true);
        if (Input.GetKey(KeyCode.G))
        {
            botonClick.SetBool("Click", true);
            verde2.SetActive(true);
            puertaCerrar.SetBool("Cerrar", true);
            pressG.SetActive(false);
            StartCoroutine(Scene());
        }
    }

    public void OnTriggerExit(Collider other)
    {
        pressG.SetActive(false);
    }

    public IEnumerator Scene()
    {
        subennivel.Play();
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        //yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(nextLevelIndex);

        RewriteData rewriteData = FindObjectOfType<RewriteData>();

        rewriteData.SaveLevel(savedLevelIndex);
    }

}
