using UnityEngine;

//Base weapon script for the player
public class WeaponScript : MonoBehaviour
{
    //Variables
    public float damage; //damage dealt by the weapon
    public float timeBetweenShooting; //time before weapon can shoot again
    public float spread; //how far the shot will travel from the center
    public float range; //how far each shot will travel
    public float reloadTime; //time it takes to reload the weapon
    public float timeBetweenShots; //time before each shot
    public int bulletsPerTap; //amount of bullets for each mouse click
    public bool allowButtonHold; //allows the player to continously shoot
    public int bulletsLeftInMag; //current ammo amount
    public int totalMagSize; //amount of ammo for a full mag
    public int bulletReserve; //total ammo amount
    private int ammoToDeduct; // used for early reload
    private int bulletsShot; //amount of bullets fired out of the weapon
    private bool shooting; //if player is shooting
    private bool readyToShoot; //if player is ready to shoot
    private bool reloading; //if player is reloading

    //Aim down sights
    public Vector3 ADS_default;
    public Vector3 ADS_on;
    public float ADS_transitionSpeed = 10f;

    //References
    public Camera cam;
    public RaycastHit rayHit;
    public LayerMask shootingLayer;
    public GameObject firepoint;
    public GameObject muzzleFlash;
    public AudioSource shot;

    void Awake()
    {
        bulletReserve -= totalMagSize;
        bulletsLeftInMag = totalMagSize;
        readyToShoot = true;
    }

    void Update()
    {
        MyInput();
    }

    void MyInput()
    {
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeftInMag < totalMagSize && !reloading)
        {
            Reload();
        }

        if (readyToShoot && shooting && !reloading && bulletsLeftInMag > 0)
        {
            bulletsShot = bulletsPerTap;
            Shoot();
        }

        //In ADS state
        if (Input.GetMouseButton(1))
        {
            transform.localPosition = Vector3.Slerp(transform.localPosition, ADS_on, ADS_transitionSpeed * Time.deltaTime);
        }

        //Leaving ADS state
        else
        {
            transform.localPosition = Vector3.Slerp(transform.localPosition, ADS_default, ADS_transitionSpeed * Time.deltaTime);
        }
    }

    void Shoot()
    {
        //Calculate weapon spread
        readyToShoot = false;
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        Vector3 direction = cam.transform.forward + new Vector3(x, y, 0);

        //Raycast
        if (Physics.Raycast(cam.transform.position, direction, out rayHit, range, shootingLayer))
        {
            Debug.DrawRay(cam.transform.position, direction * 1000, Color.cyan);
            
            if (rayHit.collider.CompareTag("Enemy"))
            {
                rayHit.collider.GetComponent<EnemyHit>().DamageEnemy(damage);
            }

            else if (rayHit.collider.CompareTag("Egg"))
            {
                rayHit.collider.GetComponent<AlienEgg>().DamageEgg(damage);
            }
        }

        bulletsLeftInMag --;
        bulletsShot --;

        //How much ammo needs to be taken away in reload calculations
        ammoToDeduct = totalMagSize - bulletsLeftInMag;

        //Muzzle flash
        GameObject flash;
        flash = Instantiate(muzzleFlash, firepoint.transform);
        Destroy(flash, 0.1f);

        shot.Play();

        Invoke("ResetShot", timeBetweenShooting);

        if (bulletsShot > 0 && bulletsLeftInMag > 0)
        {
            Invoke("Shoot", timeBetweenShots);
        }
    }

    void ResetShot()
    {
        readyToShoot = true;
    }

    void Reload()
    {
        readyToShoot = true;
        Invoke("ReloadFinished", reloadTime);
    }

    void ReloadFinished()
    {
        //Reload when player has ammo in mag and additional reserve ammo
        if (bulletsLeftInMag > 0 && bulletReserve >= ammoToDeduct )
        {
            //ammoToDeduct = totalMagSize - bulletsLeftInMag;
            bulletReserve -= ammoToDeduct;
            bulletsLeftInMag = totalMagSize;
        }

        //Reload when player loads last bullets into mag
        if (bulletsLeftInMag > 0 && bulletReserve <= ammoToDeduct)
        {
            bulletsLeftInMag += bulletReserve;
            bulletReserve = 0;
        }

        //Reload when player has no ammo in mag and reserve ammo
        if (bulletsLeftInMag == 0 && bulletReserve > 0)
        {
            bulletReserve -= totalMagSize;
            bulletsLeftInMag = totalMagSize;
        }

        reloading = false;
    }
}
