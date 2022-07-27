using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionMusic : MonoBehaviour
{
    [SerializeField] private AudioSource musicToChange = null;

    private void OnTriggerEnter(Collider other)
    {
        bool isAPlayer = other.gameObject.CompareTag("Player");
        if (isAPlayer)
        {
            ChangeSong();
        }
    }

    private void ChangeSong()
    {
        MusicManager musicManager = FindObjectOfType<MusicManager>();
        if (musicManager == null)
        {
            return;
        }

        if (musicManager.CurrentSong == null)
        {
            musicManager.CurrentSong = musicToChange;
            musicManager.CurrentSong.mute = false;
            
            return;
        }

        musicManager.CurrentSong.mute = true;
        musicManager.CurrentSong = musicToChange;
        musicManager.CurrentSong.mute = false;
    }
}
