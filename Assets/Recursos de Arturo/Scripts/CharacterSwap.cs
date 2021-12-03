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

    private PlayerMovimiento playerMovimiento;

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
            Swap();
        }
    }

    public void Swap()
    {
        if (wichCharacter == 0)
        {
            wichCharacter = possibleCharacters.Count - 1;
        }
        else
        {
            wichCharacter -= 1;
        }

        character = possibleCharacters[wichCharacter];
        character.GetComponent<PlayerController>().enabled = true;

        for (int i = 0; i < possibleCharacters.Count; i++)
        {
            if (possibleCharacters[i] != character)
            {
                possibleCharacters[i].GetComponent<PlayerController>().enabled = false;
            }           
        }
        camV.LookAt = character;
        camV.Follow = character;

        camAim.LookAt = character;
        camAim.Follow = character;
    }
}
