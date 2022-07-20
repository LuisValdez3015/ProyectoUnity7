using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotesOnScreen : MonoBehaviour
{
    [SerializeField] Image noteOnScreen;

    [SerializeField] AudioClip NoteUpAudio;

    [SerializeField] AudioClip NoteDownAudio;

    void Start()
    {
        noteOnScreen.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            noteOnScreen.enabled = true;
            AudioSource.PlayClipAtPoint(NoteUpAudio, Camera.main.transform.position);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            noteOnScreen.enabled = false;
            AudioSource.PlayClipAtPoint(NoteDownAudio, Camera.main.transform.position);
        }
    }
}
