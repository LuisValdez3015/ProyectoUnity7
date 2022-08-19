using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CerrarVideo : MonoBehaviour
{
    public VideoPlayer video;

    [SerializeField] GameObject botones;
    [SerializeField] GameObject almita;


    private void Awake()
    {
        video = GetComponent<VideoPlayer>();
        video.Play();
        video.loopPointReached += CheckOver;
    }

    void CheckOver(VideoPlayer vp)
    {
        gameObject.SetActive(false);
        botones.SetActive(true);
        almita.SetActive(true);
    }
}
