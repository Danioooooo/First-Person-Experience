using UnityEngine.SceneManagement;
using UnityEngine;

//Script used for the main menu button interactions
public class MenuScreen : MonoBehaviour
{
    //References
    public GameObject menuScreen;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    
    public void StartGame()
    {
        SceneManager.LoadScene("MainLevel");
    }

    public void Options()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
