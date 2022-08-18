using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalLvl3 : MonoBehaviour
{
    [SerializeField] int nextLevelIndex; //Es el indice en el build settings
    [SerializeField] int savedLevelIndex;

    [SerializeField] GameObject toolbagMono;
    [SerializeField] GameObject weaverMono;

    public Image black;
    public Animator anim;

    public GameObject characterSwap;

    bool toolbag;
    bool weaver;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Toolbag")
        {
            toolbagMono.SetActive(false);
            characterSwap.GetComponent<CharacterSwap>().Swap();
            toolbag = true;
        }
        if (other.gameObject.name == "Weaver")
        {
            weaverMono.SetActive(false);
            characterSwap.GetComponent<CharacterSwap>().Swap();
            weaver = true;
        }

        if (toolbag == true && weaver == true)
        {
            StartCoroutine(Scene3());
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
