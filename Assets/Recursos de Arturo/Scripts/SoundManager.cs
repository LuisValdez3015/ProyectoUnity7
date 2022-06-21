using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumenslider;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("VolumeSlider"))
        {
            PlayerPrefs.SetFloat("VolumeSlider", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void ChangeVolumen()
    {
        AudioListener.volume = volumenslider.value;
        Save();
    }

    public void Load()
    {
        volumenslider.value = PlayerPrefs.GetFloat("VolumeSlider");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("VolumeSlider", volumenslider.value);
    }
}
