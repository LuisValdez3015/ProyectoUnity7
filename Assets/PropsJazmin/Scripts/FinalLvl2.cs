using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalLvl2 : MonoBehaviour
{
    [SerializeField] int nextLevelIndex; //Es el indice en el build settings
    [SerializeField] int savedLevelIndex;

    [SerializeField] GameObject noReturn1;
    [SerializeField] GameObject noReturn2;

    public Image black;
    public Animator anim;

    public GameObject characterSwap;

    bool toolbag;
    bool weaver;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Toolbag")
        {
            characterSwap.GetComponent<CharacterSwap>().Swap();
            toolbag = true;
            noReturn1.SetActive(true);
        }
        if(other.gameObject.name == "Weaver")
        {
            characterSwap.GetComponent<CharacterSwap>().Swap();
            weaver = true;
            noReturn2.SetActive(true);
        }

        if(toolbag == true && weaver == true)
        {
            StartCoroutine(Scene3());
        }
    }

    public IEnumerator Scene3()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        //yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Lvl3CutScene");

        RewriteData rewriteData = FindObjectOfType<RewriteData>();

        rewriteData.SaveLevel(savedLevelIndex);
    }

}
