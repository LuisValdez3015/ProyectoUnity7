using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float respawnTime = 2f;

    int Key1;
    int Key2;

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

    public void AddKey(int id)
    {
        if (id == 1)
        {
            Key1++;
            //Destornillador.enabled = true;          
        }
        if (id == 2)
        {
            Key2++;
            //Llavecita.enabled = true;
        }
    }

    public void ConsumeKey(int id)
    {
        if (id == 1)
        {
            Key1--;
            //Destornillador.enabled = false;
        }
        if (id == 2)
        {
            Key2--;
            //Llavecita.enabled = false;
        }
    }

    public bool HasKey(int id)
    {
        int count = 0;

        if (id == 1)
            count = Key1;
        if (id == 2)
            count = Key2;
        if (count > 0)
            return true;
        else
            return false;
    }
}
