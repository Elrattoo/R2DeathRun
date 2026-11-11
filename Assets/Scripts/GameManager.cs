using TMPro;
using UnityEngine;
using UnityEngine.Experimental.Video;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    enum GameState {Playing, GameOver, Pause }

    [SerializeField] Transform Player;
    [SerializeField] TextMeshProUGUI scoreInput;

    [SerializeField] GameObject GameOverMenu;

    GameState gameState;
    float score;
    float scoreIncreas;
    float lastScoreIncreasHight;

 

    public bool IsGameOver => gameState == GameState.GameOver;

    void Start()
    {
        score = 0f;
        scoreIncreas = 20f;
        lastScoreIncreasHight = 0f;
        gameState = GameState.Playing;
    }

    

    void Update()
    {
        float PlayerY = Player.position.y;
        if(lastScoreIncreasHight + scoreIncreas < PlayerY)
        {
            score++;
            lastScoreIncreasHight += scoreIncreas;
            scoreInput.SetText(score.ToString("f0"));
        }
        Debug.Log("Score" + score);
    }

    public void Playerdied()
    {
        if (gameState == GameState.GameOver) return;

        gameState = GameState.GameOver;
        Debug.Log("Game Over. Score: " + score);
        GameOverMenu.SetActive(true);
        //Invoke(nameof(Restart), 2f);

    }

    public void Restart()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public int getScore()
    {
        return (int)score;
    }
}
