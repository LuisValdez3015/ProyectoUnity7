using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    [SerializeField] Slider volumenslider;

    public void OnEnable()
    {
        volumenslider.value = PlayerPrefs.GetFloat("MasterVolume", 1f);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);

        PlayerPrefs.SetFloat("MasterVolume", volume);
    }


}
