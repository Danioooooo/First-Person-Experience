using UnityEngine;

//Script for the grenade functionality
public class Grenade : MonoBehaviour
{
    //Variables
    public float delay = 3f;
    public float radius = 5f;
    public float damageAmount = 100f;
    private float countdown;
    private bool hasExploded = false;
    public Vector3 grenadePosition;
    public LayerMask grenadeExpolsionLayer;

    void Start()
    {
        //Start the fuse
        countdown = delay;
        grenadePosition = transform.position;
    }

    void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(grenadePosition, radius, grenadeExpolsionLayer);

        foreach (Collider hit in colliders)
        {
            EnemyHit enemyhealth = hit.GetComponent<EnemyHit>();

            if (enemyhealth != null)
            {
                enemyhealth.DamageEnemy(damageAmount);
            }

            AlienEgg alienEgg = hit.GetComponent<AlienEgg>();

            if (alienEgg != null)
            {
                alienEgg.DamageEgg(damageAmount);
            }

            Healthbar playerHealth = hit.GetComponent<Healthbar>();
            
            if (playerHealth != null)
            {
                playerHealth.DamagePlayer(damageAmount);
                print("executed");
            }
        }

        Destroy(gameObject);
    }
}
