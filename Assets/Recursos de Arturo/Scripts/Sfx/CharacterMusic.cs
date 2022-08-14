using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMusic : MonoBehaviour
{
    public GameObject weaver;
    public GameObject toolBag;

    private PlayerController playerController;

    [SerializeField] private AudioSource weaverBgMusic;
    [SerializeField] private AudioSource toolbagBgMusic;

    // Start is called before the first frame update
    void Start()
    {
        if (!playerController.IsInControl)
        {

        }
        //weaver.GetComponent<PlayerController>().isCharacterBgMusicEnabled
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
