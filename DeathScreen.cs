using UnityEngine;
using UnityEngine.SceneManagement;

//Script for death screen button interactions
public class DeathScreen : MonoBehaviour
{
    //Variables
    public GameObject deathScreen;
    public GameObject optionsScreen;

    //References
    public GameManager gameManager;

    public void Restart()
    {
        gameManager.PauseGame(false);
        SceneManager.LoadScene("MainLevel");
    }

    public void Options()
    {
        print("options");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
