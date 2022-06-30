using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonElevador2 : MonoBehaviour
{
    [SerializeField] GameObject verde2;

    [SerializeField] GameObject pressG;

    public Animator botonClick;
    public Animator puertaCerrar;

    [SerializeField] int nextLevelIndex; //Es el indice en el build settings
    [SerializeField] int savedLevelIndex;

    public void OnTriggerStay(Collider other)
    {
        pressG.SetActive(true);
        if (Input.GetKey(KeyCode.G))
        {
            botonClick.SetBool("Click", true);
            verde2.SetActive(true);
            puertaCerrar.SetBool("Cerrar", true);
            StartCoroutine(Scene());
        }
    }

    public IEnumerator Scene()

    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(nextLevelIndex);


        RewriteData rewriteData = new RewriteData();

        rewriteData.SaveLevel(savedLevelIndex);
    }

}
