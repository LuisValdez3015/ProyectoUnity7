using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float respawnTime = 2f;


    public void RespawnCharacter(PlayerController player)
    {
        GetComponent<CharacterSwap>().Swap();

        StartCoroutine(RespawnCoroutine(player));
    }

    IEnumerator RespawnCoroutine(PlayerController player)
    {
        yield return new WaitForSeconds(respawnTime);
        player.Respawn();
    }
}
