using UnityEngine;
using UnityEngine.Experimental.Video;

public class GameManager : MonoBehaviour
{
    enum GameState {Playing, GameOver, Pause }

    [SerializeField] Transform Player;

    GameState gameState;
    float score;


    public bool IsGameOver => gameState == GameState.GameOver;

    void Start()
    {
        score = 0f;
        float PlayerY = Player.position.y;
        gameState = GameState.Playing;
    }

    void Update()
    {
        if (gameState != GameState.Playing) return;
        
    }
}
