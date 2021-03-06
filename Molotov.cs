using UnityEngine;

//Script for making the molotov explode
public class Molotov : MonoBehaviour
{
    //Variables
    public LayerMask molotovLandLayer;
    public GameObject fireZone;
    private bool hasLanded = false;
    public float fireDuration = 10f;
    private float countdown;

    void Start()
    {
        countdown = fireDuration;
    }

    void Update()
    {
        if (!hasLanded)
        {
            //Check when molotov hits ground and turn on its damage
            float radius = 5f;
            if (Physics.CheckSphere(transform.position, radius, molotovLandLayer))
            {
                hasLanded = true;
                fireZone.SetActive(true);
            }
        }

        else
        {
            //Despawns the molotov
            countdown -= Time.deltaTime;

            if (countdown <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
