using UnityEngine;

//Script allowing alien eggs to take damage
public class AlienEgg : MonoBehaviour
{
    //Variables
    public float health;
    private AlienEggQuest eggQuest;

    void Awake()
    {
        eggQuest = GetComponentInParent<AlienEggQuest>();
    }

    public void DamageEgg(float damageEgg)
    {
        health -= damageEgg;

        if (health <= 0)
        {
            eggQuest.DestroyedEgg(1);
            Destroy(gameObject);
        }
    }
}
