using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int winningScore;
    public static GameManager Instance;
    public static event Action<GameState> OnGameStateChange;
    public static int ScorePlayer1; //idk if the scores will be useful in this script, they currently aren't
    public static int ScorePlayer2;
    public static int ScorePlayer3;
    public static int ScorePlayer4;
    public static bool Player1Ready;
    public static bool Player2Ready;
    public static bool Player3Ready;
    public static bool Player4Ready;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateGameState(GameState.MainMenu);
    }
    private void Update()
    {
        if (Player1Ready && Player2Ready && Player3Ready && Player4Ready)
        {
            UpdateGameState(GameState.Arena);
        }
    }

    public GameState state;

    public void UpdateGameState(GameState newState)
    {
        state = newState;
        switch (state)
        {
            case GameState.MainMenu: //requires updating the scenes names and adding them to the unity build
                SceneManager.LoadScene(("MainMenu"));
                break;
            case GameState.Arena:
                SceneManager.LoadScene("ArenaScene");
                break;
            case GameState.PlayerSelection:
                SceneManager.LoadScene("Playerselection");
                break;
            case GameState.Credits:
                SceneManager.LoadScene(("Credits"));
                break;
            case GameState.FinalScreen:
                SceneManager.LoadScene(("Finalscreen"));
                break;
            case GameState.ScoreUpdate:
                SceneManager.LoadScene("ScoreUpdate");
                break;
        }
        OnGameStateChange?.Invoke(newState);
    }
    //Call one of the next methods to load a scene
    public void StartSelection()
    {
        UpdateGameState(GameState.PlayerSelection);
    }
    public void DisplayCredits()
    {
        UpdateGameState(GameState.Credits);
    }
    public void BackToMenu()
    {
        UpdateGameState(GameState.MainMenu);
    }
    public void ScoreUpdate()
    {
        UpdateGameState(GameState.ScoreUpdate);
    }
    public void FinalScreen()
    {
        UpdateGameState(GameState.FinalScreen);
    }
    public enum GameState
    {
        MainMenu,
        PlayerSelection,
        Credits,
        Arena,
        ScoreUpdate,
        FinalScreen
    }
}
