using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CharacterSwap : MonoBehaviour
{
    [SerializeField] private Transform character;
    [SerializeField] private List<Transform> possibleCharacters;
    [SerializeField] private int wichCharacter;
    [SerializeField] private CinemachineVirtualCamera camV;
    [SerializeField] private CinemachineVirtualCamera camAim;

    void Start()
    {
        if (character == null && possibleCharacters.Count >= 1)
        {
            character = possibleCharacters[0];
        }
        Swap();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (wichCharacter == 0)
            {
                wichCharacter = possibleCharacters.Count - 1;
            }
            else
            {
                wichCharacter -= 1;
            }
            Swap();
        }
    }

    public void Swap()
    {
        character = possibleCharacters[wichCharacter];
        character.GetComponent<PlayerMovimiento>().enabled = true;

        for (int i = 0; i < possibleCharacters.Count; i++)
        {
            if (possibleCharacters[i] != character)
            {
                possibleCharacters[i].GetComponent<PlayerMovimiento>().enabled = false;
            }           
        }
        camV.LookAt = character;
        camV.Follow = character;

        camAim.LookAt = character;
        camAim.Follow = character;
    }
}
