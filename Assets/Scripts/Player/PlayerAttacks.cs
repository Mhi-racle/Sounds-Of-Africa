using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    public GameObject fireball;
    public Transform fireBallPoint;
    public Animator PlayerAnimator;
    public float fireballSpeed = 600;
    public Slider arrowStamina;
    public static float arrowStaminaValue = 100f;
    public float staminaReductionValue = 10f;
    public float staminaiIncrementValue = .05f;

    void Start()
    {
        arrowStaminaValue = 100f;
    }
    public void PlayFireBallAnimation()
    {
        PlayerAnimator.SetTrigger("fireballAttack");

    }

    void Update()
    {
        arrowStamina.value = arrowStaminaValue;
        // if (arrowStaminaValue < 30 &&)
        // {
        //     arrowStaminaValue += staminaiIncrementValue * Time.deltaTime;
        // }
        // while (arrowStaminaValue < 100)
        // {
        //     if (arrowStaminaValue > 0 && arrowStaminaValue < 40f)
        //     {
        //         arrowStaminaValue += staminaiIncrementValue * Time.deltaTime;
        //     }

        // }

    }
    public void Attack()
    {
        if (!PlayerController.isGrounded)
        {
            return;
        }
        if (!PlayerManager.axeIsActive)
        {

            PlayFireBallAnimation();

        }
        else
        {
            AxeAttack();
        }
    }
    public void FireballAttack()
    {
        if (arrowStaminaValue < 10)
        {
            return;
        }
        {
            GameObject ball = Instantiate(fireball, fireBallPoint.position, Quaternion.identity);
            ball.GetComponent<Rigidbody>().AddForce(fireBallPoint.forward * fireballSpeed);
            arrowStaminaValue -= staminaReductionValue;
        }

    }

    public void AxeAttack()
    {

        if (PlayerController.isGrounded)
        {
            PlayerAnimator.SetTrigger("Attack");
        }
    }


}
