using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public int healthIncremet = 80;
    public DialogueTrigger dialogueTrigger;
    public DialogueTrigger dialogueTrigger2;
    public int staminaIncrement = 100;
    public static bool seenDrum;
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            seenDrum = false;
            dialogueTrigger2.StartDialogue();
        }

    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                seenDrum = true;
                dialogueTrigger.StartDialogue();

            }
            else
            {
                PlayerManager.currentHealth = healthIncremet;
                PlayerAttacks.arrowStaminaValue = staminaIncrement;
                collider.gameObject.GetComponent<PlayerController>().speed += 3;
                Destroy(gameObject);

            }

        }
    }
}
