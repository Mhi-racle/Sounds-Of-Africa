using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class levelSelector : MonoBehaviour
{
    public int level;
    public LoadingManager loadingManager;
    public TextMeshProUGUI levelText;


    void Start()
    {
        levelText.text = level.ToString();
        loadingManager.gameObject.SetActive(false);
    }
    public void OpenScene()
    {
        // SceneManager.LoadScene("Level " + level.ToString());
        loadingManager.gameObject.SetActive(true);
        loadingManager.sceneName = "Level " + level.ToString();
    }

    public void GoBack()
    {
        loadingManager.gameObject.SetActive(true);
        loadingManager.sceneName = "Main Menu";
    }
}
