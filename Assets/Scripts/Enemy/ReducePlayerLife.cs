using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReducePlayerLife : MonoBehaviour
{
    public int damage;
    public Animator enemy;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (enemy.GetCurrentAnimatorStateInfo(0).IsName("Mutant Swiping"))
            {
                PlayerManager.currentHealth -= damage;
                other.gameObject.transform.GetChild(1).GetComponent<Animator>().SetTrigger("Hit");
                // other.gameObject.GetComponent<CharacterController>().Move(-other.transform.position);
                // other.transform.Translate(Vector3.back * 50);
                Debug.Log("Hit player");
            }

        }
    }
}
