using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonElevador : MonoBehaviour
{
    [SerializeField] int reachRange = 50;

    [SerializeField] bool boton1;
    [SerializeField] bool boton2;

    [SerializeField] GameObject verde1;
    [SerializeField] GameObject verde2;

    public Animator anim;
    public Animator anim2;

    [SerializeField] int nextLevelIndex; //Es el indice en el build settings
    [SerializeField] int savedLevelIndex; //Es para guardarlo en un arreglo de 0, 1 y 2
    public void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Pressed");

            CheckHitObj();

            if (boton1 && boton2 == true)
            {
                StartCoroutine(Scene());
            }
        }
    }

    public void CheckHitObj()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, reachRange))
        {
            if (hit.transform.name == "Boton1")
            {
                if(Input.GetKey(KeyCode.G))
                {
                    boton1 = true;
                    anim2.SetBool("Click", true);
                    verde1.SetActive(true);
                    anim.SetBool("Cerrar", true);
                }
            }
            if (hit.transform.name == "Boton2")
            {
                anim2.SetBool("Click", true);
                verde2.SetActive(true);
                anim.SetBool("Cerrar", true);
                boton2 = true;
            }
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
