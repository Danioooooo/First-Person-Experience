using UnityEngine;

//Script used to kill enemy aliens
public class EnemyDeathHandler : MonoBehaviour
{
    //References
    private EnemyAI enemyScript;

    void Awake()
    {
        enemyScript = GetComponent<EnemyAI>();
    }

    //Called to destroy AI script
    public void EnemyDeath()
    {
        Destroy(enemyScript);
    }

    //Called to destroy enire enemy object
    public void EnemyObjDeath()
    {
        Destroy(gameObject);
    }
}
