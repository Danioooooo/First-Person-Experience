using UnityEngine;
using UnityEngine.UI;

//Script managing the players health and updating the UI
public class Healthbar : MonoBehaviour
{
    //Variables
    public Image healthbarImg;
    public float maxHealth = 1000f;
    public float currentHealth;
    private bool playerDied = false;

    //References
    public GameManager gameManager;
    public GameObject deathScreen;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        //Set UI bar visibility based on health
        healthbarImg.fillAmount = currentHealth / maxHealth;

        //Prevent health UI from overfilling
        currentHealth = Mathf.Clamp(currentHealth, 0, 1000f);

        if (currentHealth <= 0)
        {
            PlayerDied();
        }
    }

    void PlayerDied()
    {
        if (!playerDied)
        {
            gameManager.PauseGame(true);
            deathScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            playerDied = true;
        }
    }

    //Method for applying damage to the player
    public void DamagePlayer(float damage)
    {
        currentHealth -= damage;
    }
}
