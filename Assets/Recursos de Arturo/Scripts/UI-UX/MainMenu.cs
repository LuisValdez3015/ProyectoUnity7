using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button[] levelButtons;
    [SerializeField] int[] sceneIndexes;

    public Image black;
    public Animator anim;

    public void Start()
    {
        UnlockedLevels();
    }

    public void PlayGame()
    {
        StartCoroutine(Fading());
    }

    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    private void UnlockedLevels()
    {
        SavedData savedData = FindObjectOfType<LoadData>().LoadGame();
        levelButtons[0].interactable = true;
        for (int i = 1; i < savedData.levelIndex.Length; i++)
        {
            levelButtons[i].interactable = savedData.levelIndex[i - 1];
        }
    }

    public void Continue()
    {
        SavedData savedData = FindObjectOfType<LoadData>().LoadGame();
        int lastUnlockedIndex = 0;
        for (int i = 0; i < savedData.levelIndex.Length; i++)
        {
            if (savedData.levelIndex[i])
            {
                lastUnlockedIndex = i;
            }
            
        }

        LoadLevel(sceneIndexes[lastUnlockedIndex]);
    }
}
