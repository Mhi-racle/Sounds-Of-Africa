using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneManager : MonoBehaviour
{
    public LoadingManager loadingManager;
    // Start is called before the first frame update
    // void Awake()
    // {
    //     // PlayerPrefs.DeleteAll();
    //     if (PlayerPrefs.GetInt("CutScene", 0) >= 1)
    //     {
    //         loadingManager.gameObject.SetActive(true);
    //     }
    // }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            loadingManager.gameObject.SetActive(true);
        }
    }
}
