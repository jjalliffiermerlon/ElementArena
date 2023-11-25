using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class RoundManagerScript : MonoBehaviour
{
    [SerializeField] private int ScoreToWin;
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
    private int _player1Position;
    private int _player2Position;
    private int _player3Position;
    private int _player4Position;
    private List<InputDevice> inputDevices;

    void Start()
    {
        inputDevices = LobbyInputManager.instance.playersInputDevices;
        numberOfPlayer = inputDevices.Count;
        Debug.Log(numberOfPlayer);
        SpawnedPlayers = new GameObject[numberOfPlayer];
        InitializingRound();
    }

    public void collectingPlayer (GameObject player, int playerIndex)
    {
        SpawnedPlayers[playerIndex] = player;
    }

    private void InitializingRound()
    {
        for (int i = 0; i < numberOfPlayer; i++)
        {
            playerSpawnManager.AddPlayer(inputDevices[i]);
        }
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

        if (_deadPlayerNb >= 3)
        {
            ScorePlayer1 += 6 - _player1Position;
            ScorePlayer2 += 6 - _player2Position;
            ScorePlayer3 += 6 - _player3Position;
            ScorePlayer4 += 6 - _player4Position;
            _player1Position = 0;
            _player2Position = 0;
            _player3Position = 0;
            _player4Position = 0;
            _deadPlayerNb = 0;
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
            Debug.Log(SpawnedPlayers.Length);
            Destroy(SpawnedPlayers[i]);
        }

        InitializingRound();
    }
}
