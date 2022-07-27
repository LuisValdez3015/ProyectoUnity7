using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FadeAudioSource : MonoBehaviour
{
    [SerializeField] float fadeOut = 0.5f;
    [SerializeField] float fadeIn = 0.5f;

    public AudioSource musicSource;
    public AudioClip newClip;

    private void Start()
    {
        musicSource.DOFade(1f, fadeIn);
    }

    public IEnumerator MusicFade()
    {
        musicSource.DOFade(0.0f, fadeOut);
        //musicSource.DOFade, fadeIn del otro personaje //TODO
        yield return new WaitForSeconds(fadeOut);

        musicSource.clip = newClip;
        musicSource.volume = 0.0f;
        musicSource.Play();
        musicSource.DOFade(1.0f, fadeIn);

        yield return null;
    }
}
