using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
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
    private int _nbConnectedPlayers;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        AudioManager.Instance.playMusic("Menu");
    }

    private void Update()
    {
        _nbConnectedPlayers = InputTransferScript.inputDevices.Count;
        if (Player1Ready && Player2Ready && (Player3Ready||_nbConnectedPlayers < 3) && (Player4Ready||_nbConnectedPlayers < 4))
        {
            AudioManager.Instance.playMenuSound("Start");
            UpdateGameState(GameState.Arena);
            Player1Ready = false;
            Player2Ready = false;
            Player3Ready = false;
            Player4Ready = false;
        }
    }

    public static GameState state;

    private static void UpdateGameState(GameState newState)
    {
        state = newState;
        switch (state)
        {
            case GameState.MainMenu: //requires updating the scenes names and adding them to the unity build
                SceneManager.LoadScene(("StartScene"));
                break;
            case GameState.Arena:
                SceneManager.LoadScene("ArenaScene");
                AudioManager.Instance.playMusic("Play");
                break;
            case GameState.PlayerSelection:
                GameObject.Find("Canvas").transform.GetChild(0).GameObject().SetActive(false);
                GameObject.Find("Canvas").transform.GetChild(1).GameObject().SetActive(true);
                break;
            case GameState.Credits:
                SceneManager.LoadScene(("Credits"));
                break;
            case GameState.FinalScreen:
                SceneManager.LoadScene(("Finalscreen"));
                AudioManager.Instance.playMusic("End");
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
        AudioManager.Instance.playMenuSound("Choice");
        UpdateGameState(GameState.PlayerSelection);
    }
    public void DisplayCredits()
    {
        AudioManager.Instance.playMenuSound("Sound");
        UpdateGameState(GameState.Credits);
    }
    public void BackToMenu()
    {
        AudioManager.Instance.playMenuSound("Cancel");
        UpdateGameState(GameState.MainMenu);
        Player1Ready = false;
        Player2Ready = false;
        Player3Ready = false;
        Player4Ready = false;
    }
    public void ScoreUpdate()
    {
        UpdateGameState(GameState.ScoreUpdate);
    }
    public static void FinalScreen()
    {
        UpdateGameState(GameState.FinalScreen);
    }
    public void QuitGame()
    {
        AudioManager.Instance.playMenuSound("Cancel");
        Debug.Log("Closing the game");
        Application.Quit();
    }
    public void Player1Check()
    {
        AudioManager.Instance.playMenuSound("Sound");
        Player1Ready = !Player1Ready;
    }
    public void Player2Check()
    {
        AudioManager.Instance.playMenuSound("Sound");
        Player2Ready = !Player2Ready;
    }
    public void Player3Check()
    {
        AudioManager.Instance.playMenuSound("Sound");
        Player3Ready = !Player3Ready;
    }
    public void Player4Check()
    {
        AudioManager.Instance.playMenuSound("Sound");
        Player4Ready = !Player4Ready;
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
