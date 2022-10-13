using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Message[] messages;

    void Start()
    {
        Time.timeScale = 1;
        StartDialogue();



    }
    public void StartDialogue()
    {
        FindObjectOfType<DialogManager>().OpenDialog(messages);
    }
}

[System.Serializable]
public class Message
{
    public string message;
    public Sprite sprite;
}
