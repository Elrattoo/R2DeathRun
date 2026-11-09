using TMPro;
using UnityEngine;
using UnityEngine.Experimental.Video;

public class GameManager : MonoBehaviour
{
    enum GameState {Playing, GameOver, Pause }

    [SerializeField] Transform Player;
    [SerializeField] TextMeshProUGUI scoreInput;

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
}
