using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;

    public CinemachineBrain cinemachineBrain;

    public GameObject virtualCamera;

    public AudioSource pauseAudio;

    //public AudioSource resumeAudio;

    public void Start()
    {
        Cursor.visible = Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {

                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        Cursor.visible = Cursor.visible = false;
        cinemachineBrain.enabled = true;
        virtualCamera.SetActive(true);

        AudioSource[] audios = FindObjectsOfType<AudioSource>();

        foreach (AudioSource a in audios)
        {
            a.UnPause();
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        Cursor.visible = Cursor.visible = true;
        cinemachineBrain.enabled = false;
        virtualCamera.SetActive(false);


        AudioSource[] audios = FindObjectsOfType<AudioSource>();

        foreach (AudioSource a in audios)
        {
            a.Pause();
        }
        //PosponerSonidoPausa();
    }

    //IEnumerator PosponerSonidoPausa()
    //{
    //    pauseAudio.Play();

    //    yield return new WaitForSeconds(2f);

    //    AudioSource[] audios = FindObjectsOfType<AudioSource>();

    //    foreach (AudioSource a in audios)
    //    {
    //        a.Pause();
    //    }
    //}

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
