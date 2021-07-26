using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of GameManager found!");
            return;
        }

        instance = this;
    }
    #endregion

    public bool gameIsPaused;

    public GameObject finishMenu;

    private void Start()
    {
        gameIsPaused = false;
    }

    public void FinishLevel()
    {
        Pause();
        finishMenu.SetActive(true);
    }

    public void RestartLevel()
    {
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Pause()
    {
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    private void Resume()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
}
