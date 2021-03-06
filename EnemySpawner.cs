using UnityEngine;

//Script used to spawn enemies randomly
public class EnemySpawner : MonoBehaviour
{
    //References
    public GameManager gameManager;
    public GameObject[] enemies;

    //Variables
    private int rand;
    private float startTimeSpawn;
    public float timeToSpawn;

    void Start()
    {
        startTimeSpawn = gameManager.spawnTime;
        timeToSpawn = startTimeSpawn;
    }

    void Update()
    {
        if (timeToSpawn <= 0)
        {
            if (gameManager.totalEnemyCount < gameManager.enemyLimit)
            {
                rand = Random.Range(0, enemies.Length);
                Instantiate(enemies[rand], transform.position, Quaternion.identity);
                timeToSpawn = startTimeSpawn;
            }

            else
            {
                timeToSpawn = startTimeSpawn;
            }
        }

        else
        {
            timeToSpawn -= Time.deltaTime;
        }
    }
}
