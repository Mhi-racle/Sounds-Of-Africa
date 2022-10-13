using UnityEngine.SceneManagement;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{

    public GameObject pauseCanvas;
    public GameObject GameCanvas;
    public GameObject gameOverCanvas;
    public static bool isGameOver;
    public LoadingManager loadingManager;
    public int enemyCount;
    void Start()
    {
        loadingManager.gameObject.SetActive(false);
        if (DialogManager.isActive)
        {
            return;
        }
        else
        {
            pauseCanvas.SetActive(false);
            GameCanvas.SetActive(true);
            isGameOver = false;
        }

    }


    void Update()
    {
        if (DialogManager.isActive)
        {
            GameCanvas.SetActive(false);
        }
        if (isGameOver)
        {
            // StartCoroutine(GameOver());
        }

    }
    public void PauseGame()
    {
        pauseCanvas.SetActive(true);
        GameCanvas.SetActive(false);
        gameOverCanvas.SetActive(false);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        pauseCanvas.SetActive(false);
        GameCanvas.SetActive(true);
        Time.timeScale = 1;
    }

    public void GameOver()
    {

        Time.timeScale = 0;
        gameOverCanvas.SetActive(true);
        GameCanvas.SetActive(false);
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToLevel(string LevelToGoTo)
    {
        loadingManager.gameObject.SetActive(true);
        loadingManager.sceneName = LevelToGoTo;
    }
}


