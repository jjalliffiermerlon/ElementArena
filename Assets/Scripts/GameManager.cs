using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int winningScore;
    public static GameManager Instance;
    public static event Action<GameState> OnGameStateChange;
    public static int ScorePlayer1;
    public static int ScorePlayer2;
    public static int ScorePlayer3;
    public static int ScorePlayer4;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateGameState(GameState.MainMenu);
        //SceneManager.LoadScene(MainMenu); //edit to actual scene name
    }

    public GameState state;

    public void UpdateGameState(GameState newState)
    {
        state = newState;
        switch (state)
        {
            case GameState.MainMenu:
                break;
            case GameState.Arena:
                break;
            case GameState.PlayerSelection:
                break;
            case GameState.Credits:
                break;
            case GameState.FinalScreen1:
                break;
            case GameState.FinalScreen2:
                break;
            case GameState.FinalScreen3:
                break;
            case GameState.FinalScreen4:
                break;
            case GameState.ScoreUpdate:
                VictoryHandler();
                break;
        }
        OnGameStateChange?.Invoke(newState);
    }

    private void VictoryHandler()
    {
        
        UpdateGameState(GameState.FinalScreen1);
    }
    public enum GameState
    {
        MainMenu,
        PlayerSelection,
        Credits,
        Arena,
        ScoreUpdate,
        FinalScreen1,
        FinalScreen2,
        FinalScreen3,
        FinalScreen4
    }
}
