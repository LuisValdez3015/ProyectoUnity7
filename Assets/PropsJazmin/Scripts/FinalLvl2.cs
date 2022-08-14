using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalLvl2 : MonoBehaviour
{
    [SerializeField] int nextLevelIndex; //Es el indice en el build settings
    [SerializeField] int savedLevelIndex;

    public Image black;
    public Animator anim;

    public GameObject characterSwap;

    bool toolbag;
    bool weaver;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Toolbag")
        {
            toolbag = true;
            Debug.Log("Tool");
        }
        if(other.gameObject.name == "Weaver")
        {
            weaver = true;
            Debug.Log("wea");
        }

        if(toolbag == true && weaver == true)
        {
            StartCoroutine(Scene3());
            Debug.Log("Hola?");
        }
    }

    public IEnumerator Scene3()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        //yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(nextLevelIndex);

        RewriteData rewriteData = FindObjectOfType<RewriteData>();

        rewriteData.SaveLevel(savedLevelIndex);
    }

}
