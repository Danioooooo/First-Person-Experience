using UnityEngine;

//Script which is referenced by shot landing on enemy
//adds damage to the enemy affected by multiplier
public class EnemyHit : MonoBehaviour
{
    //Variables
    private EnemyAI enemyRef;
    public float damageMultiplier = 1;

    void Awake()
    {
        //Get reference to enemy's health value by travelling to the root
        //(where the script is located)
        enemyRef = transform.root.GetComponent<EnemyAI>();
    }

    //Take damage amount and add multiplier
    public void DamageEnemy(float damage)
    {
        if (enemyRef != null)
        {
            enemyRef.TakeDamage(damage * damageMultiplier);
        }
    }
}
