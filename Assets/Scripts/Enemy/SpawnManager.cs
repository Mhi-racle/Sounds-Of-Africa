using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
public class SpawnManager : MonoBehaviour
{
    public static int spawnCount;
    public int numberOfEnemies;
    private int originalEnemyNumber;
    public GameObject enemy;
    public GameObject drum;
    bool drumAppeared;
    public GameObject gate;
    public float minXPosition;
    public float maxXPosition;
    public float increment = 1;
    public static float enemyNewSpeed = 3;
    public TextMeshProUGUI enemyCountText;
    public float drumsInstantiated = 0;

    void Awake()
    {
        spawnCount = 0;
    }
    void Start()
    {
        enemyNewSpeed = 3;
        originalEnemyNumber = numberOfEnemies;

        drumAppeared = false;
        drumsInstantiated = 0;
    }

    void Update()
    {
        if (DialogManager.isActive)
        {
            return;
        }
        if (spawnCount < 0)
        {
            return;
        }
        if (FindObjectsOfType<Enemy>().Length == 0 && numberOfEnemies > 0)
        {

            SpawnEnemy();
        }

        if (PlayerManager.currentHealth < 50 && SceneManager.GetActiveScene().buildIndex != 1)
        {
            if (FindObjectsOfType<Powerup>().Length > 0)
            {
                return;
            }
            else
            {
                if (numberOfEnemies > 0 && drumsInstantiated == 0)
                {
                    Instantiate(drum, new Vector3(Random.Range(-10, 10), drum.transform.position.y, drum.transform.position.z), drum.transform.rotation);
                    drumsInstantiated++;
                    drumAppeared = true;
                    StartCoroutine(changeText());
                }
            }
        }

        if (drumAppeared)
        {
            return;
        }
        enemyCountText.text = "Defeat all the golems : " + spawnCount + "/" + originalEnemyNumber.ToString();
        if (spawnCount == originalEnemyNumber)
        {

            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                enemyCountText.text = "Find the drum";
                Instantiate(drum, new Vector3(Random.Range(-50, 50), drum.transform.position.y, drum.transform.position.z), drum.transform.rotation);
            }
            else
            {
                enemyCountText.text = "Find the gate and pass through it";
                Instantiate(gate, new Vector3(Random.Range(-10, 10), drum.transform.position.y, gate.transform.position.z), gate.transform.rotation);
            }

            spawnCount = -1;
        }
    }

    void SpawnEnemy()
    {
        if (numberOfEnemies > 0)
        {
            // for (int i = 0; i < number; i++)
            // {
            enemyNewSpeed += increment;
            Instantiate(enemy, new Vector3(Random.Range(minXPosition, maxXPosition), 1.36f, 0f), enemy.transform.rotation);
            //}
            numberOfEnemies--;
        }
    }
    IEnumerator changeText()
    {
        enemyCountText.text = "A drum has appeared, search for it to gain healing";
        yield return new WaitForSeconds(4f);
        enemyCountText.text = "Defeat all the golems : " + spawnCount + "/" + originalEnemyNumber.ToString();
        drumAppeared = false;
    }

}
