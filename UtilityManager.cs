using UnityEngine;
using UnityEngine.UI;

//Script managing players utilities
public class UtilityManager : MonoBehaviour
{
    //General throw variables
    public float throwForce = 20f;
    public Transform throwPoint;

    //Grenade variables
    public GameObject grenadePrefab;
    public int grenadeCount = 3;
    public bool grenadeSelected = true;

    //Molotov variables
    public GameObject molotovPrefab;
    public int molotovCount = 3;

    //References
    public Text utilityCountText;

    void Update()
    {
        if (grenadeSelected)
        {
            utilityCountText.text = grenadeCount.ToString();

            if (Input.GetMouseButtonDown(2) && grenadeCount > 0)
            {
                ThrowGrenade();
                grenadeCount -= 1;
            }
        }

        else
        {
            utilityCountText.text = molotovCount.ToString();
            
            if (Input.GetMouseButtonDown(2) && molotovCount > 0)
            {
                ThrowMolotov();
                molotovCount -= 1;
            }
        }

        
    }

    void ThrowGrenade()
    {
        //Spawn grenade
        GameObject grenade = Instantiate(grenadePrefab, throwPoint.position, transform.rotation);

        //Get reference to grenades physics
        Rigidbody rb = grenade.GetComponentInChildren<Rigidbody>();

        //Throw
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    }

    void ThrowMolotov()
    {
        GameObject molotov = Instantiate(molotovPrefab, throwPoint.position, transform.rotation);

        Rigidbody rb = molotov.GetComponent<Rigidbody>();

        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    }
}
