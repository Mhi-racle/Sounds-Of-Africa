using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    public int sceneToLoad;
    public LoadingManager loadingManager;

    void Start()
    {
        // loadingManager = FindObjectOfType<LoadingManager>();
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {

            PlayerPrefs.SetInt("levelsUnlocked", SceneManager.GetActiveScene().buildIndex + 1);
            loadingManager.gameObject.SetActive(true);
            loadingManager.sceneName = "LevelSelection";
        }
    }
}
