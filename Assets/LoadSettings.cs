using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class LoadSettings : MonoBehaviour
{
    public AudioMixer audioMixer;

    void Start()
    {
        float volume = PlayerPrefs.GetFloat("MasterVolume", 1f);

        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
    }
}
