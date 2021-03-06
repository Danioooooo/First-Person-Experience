using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

//Returns back to menu after game finishes
public class EndCredits : MonoBehaviour
{
    //Variables
    public float time = 10f;

    void Start()
    {
        StartCoroutine(EndGame());
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("Menu");
    }
}
