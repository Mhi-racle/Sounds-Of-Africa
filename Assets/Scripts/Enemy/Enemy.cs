using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string currentState = "IdleState";
    private Transform target;
    public float chaseRange = 7;
    public Animator animator;
    public float speed = 3f;
    public float attackRange = 4f;
    public GameObject dieEffect;
    public float turnTime = 2f;
    public SpawnManager spawnManager;
    private GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = gameObject;
        speed = SpawnManager.enemyNewSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if (currentState == "IdleState")
        {
            if (distance < chaseRange)
            {
                currentState = "ChaseState";
            }
        }
        else if (currentState == "ChaseState")
        {
            //play the animation
            animator.SetTrigger("chase");
            animator.SetBool("isAttacking", false);

            if (distance < attackRange)
            {
                currentState = "attackState";
            }
            //move the player
            if (target.position.x > transform.position.x)
            {

                //move right
                transform.Translate(transform.right * speed * Time.deltaTime);
                StartCoroutine(RotateRight());
            }
            else
            {
                //move left
                transform.Translate(-transform.right * speed * Time.deltaTime);
                StartCoroutine(RotateLeft());
            }

        }
        else if (currentState == "attackState")
        {
            animator.SetBool("isAttacking", true);
            if (distance > attackRange)
            {
                currentState = "ChaseState";
            }
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    public void Die()
    {
        Instantiate(dieEffect, transform.position, Quaternion.identity);
        SpawnManager.spawnCount++;
        Destroy(gameObject);

        //let something be left after the enemy dies to recharge the player
    }

    // public void SpawnEnemy(int number, GameObject player)
    // {
    //     if (SpawnManager.numberOfEnemies > 0)
    //     {


    //         for (int i = 0; i < number; i++)
    //         {
    //             Instantiate(enemy, new Vector3(Random.Range(transform.position.x, transform.position.x + Random.Range(-5, 5)), 1.36f, 0f), enemy.transform.rotation);
    //         }
    //         SpawnManager.numberOfEnemies--;
    //     }
    // }
    IEnumerator RotateRight()
    {
        yield return new WaitForSeconds(turnTime);
        transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    IEnumerator RotateLeft()
    {
        yield return new WaitForSeconds(turnTime);
        transform.rotation = Quaternion.identity;
    }
}
