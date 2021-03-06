using UnityEngine;

//Script responsible for the fire effect on the molotov
public class MolotovDamage : MonoBehaviour
{
    //Variables
    public float damage = 3f;

    //Grab health scripts from colliding objects and apply damage
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Healthbar playerHealth = other.GetComponent<Healthbar>();

            if (playerHealth != null)
            {
                playerHealth.DamagePlayer(damage);
            }
        }

        EnemyAI enemyHealth = other.GetComponent<EnemyAI>();

        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damage);
        }

        
    }
}
