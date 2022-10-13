using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadingManager : MonoBehaviour
{
    public Slider slider;
    public string sceneName;

    // void Awake()
    // {
    //     // index = StaticVariables.sceneIndex;
    //     LoadLevel(sceneName);
    // }
    void Start()
    {
        LoadLevel(sceneName);
    }
    void LoadLevel(string name)
    {
        StartCoroutine(LoadAsynLevel(name));
    }

    IEnumerator LoadAsynLevel(string name)
    {

        AsyncOperation operation = SceneManager.LoadSceneAsync(name, LoadSceneMode.Single);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            Debug.Log(progress);
            slider.value = progress;
            yield return null;
        }
    }
}
