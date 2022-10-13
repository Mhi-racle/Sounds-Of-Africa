using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public LoadingManager loadingManager;
    public void mainMenu()
    {
        loadingManager.gameObject.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }
}
