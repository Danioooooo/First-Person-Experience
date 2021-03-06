using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//Script managing the players weapons
public class WeaponManager : MonoBehaviour
{
    //Weapon manager variables
    public GameObject[] loadout = new GameObject[2];
    //private GameObject currentWeapon;
    private int weaponPointer;
    public bool wpnManagerInput = true;
    private WeaponScript currentWpnScript;

    //UI variables
    public Text currentWeaponText;
    public Text ammCountText;
    private float textDisplayDuration = 3f;


    void Start()
    {
        //Set primary weapon
        SwitchWeapons(0);
    }

    void Update()
    {
        if (wpnManagerInput)
        {
            WeaponManagerInput();
        }

        ammCountText.text = currentWpnScript.bulletsLeftInMag.ToString() + " / " + currentWpnScript.bulletReserve.ToString();
    }

    void WeaponManagerInput()
    {
        //Scroll up
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            SwitchWeapons((weaponPointer < 1) ? weaponPointer +1 : 0);
        }

        //Scroll down
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            SwitchWeapons((weaponPointer > 0) ? weaponPointer -1 : 1);
        }
    }

    void SwitchWeapons(int index)
    {
        for (int i = 0; i < loadout.Length; i++)
        {
            loadout[i].SetActive(false);
        }

        currentWpnScript = loadout[index].GetComponent<WeaponScript>();

        loadout[index].SetActive(true);
        weaponPointer = index;

        StartCoroutine(WeaponChangeNotification());
    }

    //Used to replace weapon with the replacement weapon parameter
    public void ReplaceWeapon(GameObject replacementWeapon)
    {
        loadout[weaponPointer].SetActive(false);
        loadout[weaponPointer] = replacementWeapon;
        loadout[weaponPointer].GetComponent<WeaponScript>();
        replacementWeapon.SetActive(true);
    }

    //Displays the current weapon held
    IEnumerator WeaponChangeNotification()
    {
        int weaponCount = weaponPointer +1;
        currentWeaponText.text = ("Weapon " + weaponCount + " selected").ToString();

        currentWeaponText.gameObject.SetActive(true);
        yield return new WaitForSeconds(textDisplayDuration);
        currentWeaponText.gameObject.SetActive(false);
    }
}
