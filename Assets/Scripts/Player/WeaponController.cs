using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public int damage = 15;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyController>().enemyHealth -= damage;
            other.gameObject.GetComponent<Enemy>().animator.SetTrigger("Hit");
            Debug.Log("Hit Enemy");
        }
    }
}
