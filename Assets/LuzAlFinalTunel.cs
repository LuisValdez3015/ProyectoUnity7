using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzAlFinalTunel : MonoBehaviour
{
    //public GameObject player;

    public CharacterSwap characterSwap;

    private int playerCount;

    public GameControl gameControl;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerCount++;
            if (playerCount == 1)
            {
                characterSwap.Swap();
            }
            other.gameObject.SetActive(false);
            if (playerCount == 2)
            {
                gameControl.endGame();
            }
        }
    }

    //public void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        for (int i = 0; i < characters.Count; i++)
    //        {
    //            characters[i].SetActive(false);
    //        }
    //        characterSwap.Swap();
    //    }
    //}
}

