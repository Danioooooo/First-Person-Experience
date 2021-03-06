using UnityEngine;
using UnityEngine.UI;

//Script managing the players score count
public class ScoreManager : MonoBehaviour
{
    //Variables
    public Text scoreText;
    public int score;
    
    void Update()
    {
        scoreText.text = "$" + score.ToString();
    }

    public void AddScore(int scoreToAdd)
    {
        score = score + scoreToAdd;
    }
}
