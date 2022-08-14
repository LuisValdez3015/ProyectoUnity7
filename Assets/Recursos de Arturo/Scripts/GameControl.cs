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
        SceneManager.LoadScene("BadEnding");
        //player.SetActive(false);
        //characterSwap.Swap();
        //canvasObject.SetActive(true);
        //contador.SetActive(false);
    }
}
