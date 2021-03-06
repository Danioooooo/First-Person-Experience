using UnityEngine;

//Script for enemy bullet functionality
public class EnemyBullet : MonoBehaviour
{
    //Variables
    public float damage;

    void Update()
    {
        Destroy(gameObject, 2f);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            Healthbar health = col.transform.GetComponent<Healthbar>();

            if (health != null)
            {
                health.DamagePlayer(damage);
            }
        }
    }
}
