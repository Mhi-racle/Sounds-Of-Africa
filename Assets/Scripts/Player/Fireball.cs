using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public GameObject damageEffect;
    public int enemyDamage = 20;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            string enemyState = other.gameObject.GetComponent<Enemy>().currentState;
            if (enemyState == "IdleState")
            {
                other.gameObject.GetComponent<Enemy>().currentState = "ChaseState";
            }

            Instantiate(damageEffect, transform.position, damageEffect.transform.rotation);
            other.gameObject.GetComponent<EnemyController>().enemyHealth -= enemyDamage;
            other.gameObject.GetComponent<Enemy>().animator.SetTrigger("Hit");
            Vector3 backDist = other.gameObject.transform.position - transform.position;
            other.gameObject.GetComponent<Rigidbody>().AddForce(backDist * 10, ForceMode.Impulse);
            Destroy(gameObject);

        }
    }
}
