using UnityEngine.UI;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int enemyHealth = 100;
    public Slider healthBar;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = enemyHealth; //updates the health bar

        if (enemyHealth <= 0)
        {
            GetComponent<Enemy>().Die();
        }
    }
}
