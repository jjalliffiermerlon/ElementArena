using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class RoundManagerScript : MonoBehaviour
{
    [SerializeField] int ScoreToWin;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform[] spawnPoints;
    public int numberOfPlayer = 2;
    [SerializeField] private GameObject scoreScreen;
    [SerializeField] private PlayerSpawnManager playerSpawnManager;
    private GameObject[] SpawnedPlayers;
    public int ScorePlayer1;
    public int ScorePlayer2;
    public int ScorePlayer3;
    public int ScorePlayer4;
    public static int LastDeadPlayer = -1;//takes the Id of a player that just died
    public static int OtherDeadPlayer = -1;//failsafe in case 2 players die at the same frame
    private int _deadPlayerNb;
    private int _player1Position = 1;
    private int _player2Position = 1;
    private int _player3Position = 1;
    private int _player4Position = 1;
    private string scorestr;
    private List<InputDevice> devicesInput;

    void Start()
    {
        devicesInput = InputTransferScript.inputDevices;
        numberOfPlayer = devicesInput.Count;
        SpawnedPlayers = new GameObject[numberOfPlayer];
        StartCoroutine(InitializingRound());
    }

    IEnumerator InitializingRound()
    {
        for (int i = 0; i < numberOfPlayer; i++)
        {
            playerSpawnManager.AddPlayer(devicesInput[i], i);
        }
        yield return new WaitForSeconds(2);
        playerSpawnManager.startGame();
        AudioManager.Instance.playRoundManagerSound("Count");
        yield return new WaitForSeconds(0.5f);
        playerSpawnManager.playerInputManager.DisableJoining();
        AudioManager.Instance.playRoundManagerSound("Go");
    }

    public void CollectingPlayers(GameObject player, int playerIndex)
    {
        SpawnedPlayers[playerIndex] = player;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            StartCoroutine(roundFinished());
        }
        if (LastDeadPlayer != -1)
        {
            switch (LastDeadPlayer)
            {
                case 0:
                    _player1Position = 4 - _deadPlayerNb;
                    break;
                case 1:
                    _player2Position = 4 - _deadPlayerNb;
                    break;
                case 2:
                    _player3Position = 4 - _deadPlayerNb;
                    break;
                case 3:
                    _player4Position = 4 - _deadPlayerNb;
                    break;
            }
            _deadPlayerNb += 1;
            LastDeadPlayer = -1;
        }

        if (OtherDeadPlayer != -1)
        {
            LastDeadPlayer = OtherDeadPlayer;
            OtherDeadPlayer = -1;
        }

        if (_deadPlayerNb >= numberOfPlayer - 1)
        {
            ScorePlayer1 += numberOfPlayer - _player1Position + 1;
            ScorePlayer2 += numberOfPlayer - _player2Position + 1;
            ScorePlayer3 += numberOfPlayer - _player3Position + 1;
            ScorePlayer4 += numberOfPlayer - _player4Position + 1;
            switch (numberOfPlayer)
            {
                case 2:
                    ScorePlayer3 = 0;
                    ScorePlayer4 = 0;
                    break;
                case 3:
                    ScorePlayer4 = 0;
                    break;
            }
            ScoresStoring.ScorePlayer1 = ScorePlayer1;
            ScoresStoring.ScorePlayer2 = ScorePlayer2;
            ScoresStoring.ScorePlayer3 = ScorePlayer3;
            ScoresStoring.ScorePlayer4 = ScorePlayer4;
            _player1Position = 1;
            _player2Position = 1;
            _player3Position = 1;
            _player4Position = 1;
            _deadPlayerNb = 0;
            scorestr = $"Scores :\n Joueur 1 : {ScorePlayer1} points\n Joueur 2 : {ScorePlayer2} points\n Joueur {3} : {ScorePlayer3} points\n Joueur 4 : {ScorePlayer4} points";
            StartCoroutine(roundFinished());
        }
        if (Math.Max(Math.Max(ScorePlayer1, ScorePlayer2), Math.Max(ScorePlayer3, ScorePlayer4)) >= ScoreToWin)
        {
            GameManager.FinalScreen();
        }
    }

    IEnumerator roundFinished()
    {
        Time.timeScale = 0;
        scoreScreen.SetActive(true);
        yield return new WaitForSecondsRealtime(10);
        scoreScreen.SetActive(false);

        for (int i = 0; i< SpawnedPlayers.Length; i++)
        {
            Destroy(SpawnedPlayers[i]);
        }

        InitializingRound();
    }
}