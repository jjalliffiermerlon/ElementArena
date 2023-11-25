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
    private int _player1Position;
    private int _player2Position;
    private int _player3Position;
    private int _player4Position;
    private string scorestr;

    void Start()
    {
        SpawnedPlayers = new GameObject[numberOfPlayer];
        InitializingRound();
    }

    private void InitializingRound()
    {
        for (int i = 0; i < numberOfPlayer; i++)
        {
            /*InputDevice inputdevice = new InputDevice();
            playerSpawnManager.AddPlayer(inputdevice);*/

            SpawnedPlayers[i] = (Instantiate(playerPrefab));
            SpawnedPlayers[i].transform.position = spawnPoints[i].position;
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
