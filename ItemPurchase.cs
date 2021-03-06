using UnityEngine;
using UnityEngine.UI;

//Script used to allow purchase of items in store UI
public class ItemPurchase : MonoBehaviour
{
    //Variables
    public GameObject weapon;
    public int cost;
    public int ammoOnPurchase;
    public string itemDescription;
    public Text descriptionText;
    public Text costText;

    //References
    public ScoreManager scoreScript;
    public WeaponManager weaponManaging;
    private WeaponScript gunScript;


    void Awake()
    {
        PrepareItem();

        gunScript = weapon.GetComponent<WeaponScript>();
    }

    void PrepareItem()
    {
        descriptionText.text = itemDescription.ToString();
        costText.text = "$" + cost.ToString();
    }

    public void ItemBought()
    {
        if (scoreScript.score >= cost)
        {
            print("stonks!");
            scoreScript.score -= cost;
            weaponManaging.ReplaceWeapon(weapon);

            if (gunScript.bulletsLeftInMag == 0)
            {
                gunScript.bulletsLeftInMag = ammoOnPurchase;
            }
        }
    }
}
