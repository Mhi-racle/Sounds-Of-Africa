using UnityEngine.UI;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static int currentHealth;
    public Slider healthBar;
    public Animator playerAnimator;
    public static bool axeIsActive;
    public GameObject axe;
    public GameObject axeAtTheBack;
    public Sprite[] weaponIcons;
    public Image[] ButtonImages;
    public Button inactiveButton;
    public static bool isReloading;
    public GameObject explosion;
    public GameManager gameManager;
    void Start()
    {
        currentHealth = 100;

        axeIsActive = true;
    }
    void Update()
    {
        if (GameManager.isGameOver)
        {
            return;
        }
        //Sets the healthbar according to the player's life
        healthBar.value = currentHealth;

        //checks if the game is over and it plays the dead animaiton if it is
        //game over
        if (currentHealth <= 0)
        {

            GameManager.isGameOver = true;
            playerAnimator.SetTrigger("Die");
            return;
        }
    }

    //diables and enables the axe
    public void ChangeWeapon()
    {
        // if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Unarmed Idle"))
        // {

        if (axeIsActive) //also checks ifthe player is idle
        {
            // axe.SetActive(false);
            isReloading = true;
            playerAnimator.SetTrigger("Disarm");
            axeIsActive = false;
            ButtonImages[0].sprite = weaponIcons[1];
            ButtonImages[1].sprite = weaponIcons[0];
            isReloading = false;
        }

        else
        {

            // axe.SetActive(true);
            isReloading = true;
            playerAnimator.SetTrigger("Equip");
            axeIsActive = true;
            ButtonImages[0].sprite = weaponIcons[0];
            ButtonImages[1].sprite = weaponIcons[1];
            isReloading = false;
        }
        //}
    }

    public void PutAxeAtTheBack()
    {
        axe.SetActive(false);
        axeAtTheBack.SetActive(true);
    }

    public void putAxeInHand()
    {
        axe.SetActive(true);
        axeAtTheBack.SetActive(false);
    }

    public void Die()
    {

        gameManager.GameOver();
    }
}
