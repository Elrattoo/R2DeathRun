using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject container;
    public GameManager gameManager;

    private int currentScore;
    public TextMeshProUGUI finalscoreText;
    public TextMeshProUGUI highscoreText;

    public void Update()
    {
        HighscoreUpdate();
    }
    public void HighscoreUpdate()
    {
        currentScore = gameManager.getScore();
        if (PlayerPrefs.HasKey("SavedHighScore"))
        {
            if(currentScore > PlayerPrefs.GetInt("SavedHighScore"))
            {
                PlayerPrefs.SetInt("SavedHighScore", currentScore);
            }
        }
        else
        {
            PlayerPrefs.SetInt("SavedHighScore", currentScore);
        }
        
        finalscoreText.text = currentScore.ToString();
        highscoreText.text = PlayerPrefs.GetInt("SavedHighScore").ToString();
    }



    public void tryAgain()
    {
        gameManager.Restart();
    }

    public void gameMenu()
    {
        SceneManager.LoadScene("GameMenu");
    }

}
