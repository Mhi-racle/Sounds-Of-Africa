using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController player;
    private Vector3 direction;
    public float speed = 10;
    public float jumpForce = 10;
    public float gravity = -20;
    public static bool isGrounded;
    public bool ableToDoubleJump = true;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Animator playerAnimator;
    public Transform model;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerManager.isReloading)
        {
            return;
        }
        MoveCharacter(); //moves the character
                         // Jump(); //enables the jump

        isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundLayer); //returns true if the groundCheck gameobject is in contact with the ground
        playerAnimator.SetBool("isGrounded", isGrounded);
        direction.y += gravity * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    public void Jump()
    {


        if (isGrounded)
        {
            direction.y = -1;
            // ableToDoubleJump = true; //enables the doubleJump feature once player is on the ground
            direction.y = jumpForce;
            player.Move(direction * Time.deltaTime);

        }

        // //player can make double jump if the player is in the sky
        // else
        // {

        //     direction.y += gravity * Time.deltaTime;  //acts as gravity. Drags the player to the ground every frame. I use this because I am not using Rigidbody
        //     MoveCharacter(); //moves the character
        //     if (ableToDoubleJump)
        //     {
        //         playerAnimator.SetTrigger("doubleJump");
        //         direction.y = jumpForce;
        //         ableToDoubleJump = false;
        //     }
        // }
    }

    //moves character on the x-axis
    void MoveCharacter()
    {
        float HorizontalInput = SimpleInput.GetAxis("Horizontal");
        direction.x = HorizontalInput * speed;
        player.Move(direction * Time.deltaTime);

        if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("fireball") || playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Axe Swing"))
        {
            return;
        }
        //rotates the player based on the direction which the player is going
        if (HorizontalInput != 0)
        {
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(HorizontalInput, 0, 0));
            model.rotation = newRotation;
        }
        playerAnimator.SetFloat("Speed", Mathf.Abs(HorizontalInput));
    }



    // public void FireballAttack()
    // {
    //     playerAnimator.SetTrigger("fireballAttack");
    // }
}
