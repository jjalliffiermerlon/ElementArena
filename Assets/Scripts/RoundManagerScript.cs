using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform[] spawnPoints;
    public int numberOfPlayer = 2;
    [SerializeField] private GameObject scoreScreen;

    void Start()
    {
        for (int i = 0; i < numberOfPlayer; i++)
        {
            GameObject spawnedPlayer;
            spawnedPlayer = Instantiate(playerPrefab);
            spawnedPlayer.transform.position = spawnPoints[i].position;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            roundFinished();
        }
    }

    private void roundFinished()
    {
        scoreScreen.SetActive(true);
    }
}
