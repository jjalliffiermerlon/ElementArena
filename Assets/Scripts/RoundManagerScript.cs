using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class RoundManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform[] spawnPoints;
    public int numberOfPlayer = 2;
    [SerializeField] private GameObject scoreScreen;
    [SerializeField] private PlayerSpawnManager playerSpawnManager;
    private GameObject[] SpawnedPlayers;

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
