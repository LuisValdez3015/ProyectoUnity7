using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    private Timer timer;

    //public GameObject player;

    //private CharacterSwap characterSwap;

    //public GameObject canvasObject;
    //public GameObject contador;

    [SerializeField] GameObject toolbag;

    [SerializeField] GameObject weaver;

    void Start()
    {
        //characterSwap = GetComponent<CharacterSwap>();
        timer = gameObject.GetComponent<Timer>();
        startGame();

    }

    public void startGame()
    {
        timer.startTimer();
    }

    public void endGame()
    {
        timer.stopTimer();


        if (toolbag.activeInHierarchy && weaver.activeInHierarchy)
        {
            SceneManager.LoadScene("BadEnding");
        }
        else if (!toolbag.activeInHierarchy && weaver.activeInHierarchy) //Si toolbag salio y weaver no
        {
            SceneManager.LoadScene("ToolbagEnding");
        }
        else if (toolbag.activeInHierarchy && !weaver.activeInHierarchy) //Si weaver salio y toolbag no
        {
            SceneManager.LoadScene("WeaverEnding");
        }
        else //Ending bueno
        {
            SceneManager.LoadScene("GoodEnding");
        }
        //player.SetActive(false);
        //characterSwap.Swap();
        //canvasObject.SetActive(true);
        //contador.SetActive(false);
    }
}
