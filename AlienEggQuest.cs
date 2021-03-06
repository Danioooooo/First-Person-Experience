using UnityEngine;

//Script handling the alien egg destruction for the main quest
public class AlienEggQuest : MonoBehaviour
{
    //Variables
    public int eggsDestroyed;
    public int limit;
    public bool destroyed = false;
    public Transform transformPos;

    void Awake()
    {
        transformPos = GetComponent<Transform>();
    }

    public void DestroyedEgg(int amountDestroyed)
    {
        eggsDestroyed += amountDestroyed;

        if (eggsDestroyed >= limit)
        {
            destroyed = true;
            Destroy(gameObject);
        }
    }
}
