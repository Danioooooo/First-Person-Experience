using UnityEngine;

//Script managing various general things in the game
public class GameManager : MonoBehaviour
{
    //Enemy variables
    public int totalEnemyCount;
    public int enemyLimit;
    public float spawnTime = 30f;

    //References
    public WeaponManager wpnManager;

    //Used to keep a count of enemies in the game
    public void UpdateEnemyCount(int enemiesSpawned)
    {
        if (totalEnemyCount < enemyLimit)
        {
            totalEnemyCount += enemiesSpawned;
        }
    }

    //Used to pause the game
    public void PauseGame(bool paused)
    {
        if (paused)
        {
            Time.timeScale = 0f;
            ScriptToggle(false);
        }

        else
        {
            Time.timeScale = 1f;
            ScriptToggle(true);
        }
    }

    //Used to enable or disable main functionality scripts
    void ScriptToggle(bool toggle)
    {
        wpnManager.enabled = toggle;
    }
}
