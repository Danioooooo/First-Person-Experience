using UnityEngine.SceneManagement;
using UnityEngine;

//Script used for the pause menu button interactions
public class PauseScreen : MonoBehaviour
{
    //Variables
    public static bool gamePaused = false;
    public GameObject pauseScreen;
    public GameObject optionsScreen;

    //References
    public GameManager gameManager;

    void Update()
    {
        //Escape key pressed while playing
        if (Input.GetKeyDown(KeyCode.Escape) && !gamePaused)
        {
            Pause();
        }

        //Escape key pressed in pause screen
        else if (Input.GetKeyDown(KeyCode.Escape) && gamePaused)
        {
            Resume();
        }
    }

    public void Resume()
    {
        gamePaused = false;
        pauseScreen.SetActive(false);
        optionsScreen.SetActive(false);
        gameManager.PauseGame(gamePaused);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Pause()
    {
        gamePaused = true;
        pauseScreen.SetActive(true);
        gameManager.PauseGame(gamePaused);
        Cursor.lockState = CursorLockMode.None;
    }

    public void Options()
    {
        pauseScreen.SetActive(false);
        optionsScreen.SetActive(true);
    }

    public void Menu()
    {
        gamePaused = false;
        gameManager.PauseGame(gamePaused);
        SceneManager.LoadScene("Menu");
    }
}
