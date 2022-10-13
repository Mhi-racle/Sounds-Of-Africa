using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class DialogManager : MonoBehaviour
{
    public Image actorImage;
    public TextMeshProUGUI messageText;
    public RectTransform backgroundBox;
    public GameObject gameCanvas;
    Message[] currentMessages;
    int activeMessage = 0;
    public static bool isActive = false;
    public LoadingManager loadingManager;

    // Start is called before the first frame update
    void Start()
    {
        // sets the background box to be zero on start
        backgroundBox.transform.localScale = Vector3.zero;
        loadingManager.gameObject.SetActive(false);
        if (SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 2)
        {
            isActive = true;
            gameCanvas.SetActive(false);
            OpenDialog(currentMessages);
        }
        else
        {
            isActive = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space) && isActive)
        // {
        //(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && isActive)
        //Input.GetKeyDown(KeyCode.Space) && isActive
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && isActive))
        {
            // if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            // {
            //     return;
            // }
            NextMessage();
        }
    }
    public void OpenDialog(Message[] messages)
    {
        currentMessages = messages;
        activeMessage = 0;
        isActive = true;

        Debug.Log("Started conversation ! Loaded messages : " + messages.Length);
        DisplayMessage();

        //animating the dialog box using lean tween
        backgroundBox.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo(); //setEaseInoutExpo smoothens the animation
    }

    public void DisplayMessage()
    {
        Message messageDisplay = currentMessages[activeMessage];
        messageText.text = messageDisplay.message;
        actorImage.sprite = messageDisplay.sprite;

        //animates the text per every change
        AnimateTextColor();
    }

    //uses Lean Tween to animate the text's opacity to give a fade in and fade out effect
    void AnimateTextColor()
    {
        LeanTween.textAlpha(messageText.rectTransform, 0, 0);
        LeanTween.textAlpha(messageText.rectTransform, 1, 0.5f);
    }

    public void NextMessage()
    {
        activeMessage++;
        if (activeMessage < currentMessages.Length)
        {
            DisplayMessage();
        }
        else
        {
            Debug.Log("Coversaion ended");
            isActive = false;
            //animaition to close the dialog box
            backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            gameCanvas.SetActive(true);

            //for only level 1
            //go to the next scene after the dialogue
            if (SceneManager.GetActiveScene().buildIndex == 1 && SpawnManager.spawnCount == -1 && Powerup.seenDrum == true)
            {
                PlayerPrefs.SetInt("levelsUnlocked", SceneManager.GetActiveScene().buildIndex + 1);

                //activates the loading scene
                loadingManager.gameObject.SetActive(true);
                loadingManager.sceneName = "LevelSelection";
                // SceneManager.LoadScene("LevelSelection");
            }
        }
    }
}
