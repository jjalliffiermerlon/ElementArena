using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform[] spawnPoints;
    public int numberOfPlayer = 2;

    void Start()
    {
        for (int i = 0; i < numberOfPlayer; i++)
        {
            GameObject spawnedPlayer;
            spawnedPlayer = Instantiate(playerPrefab);
            spawnedPlayer.transform.position = spawnPoints[i].position;
        }
    }
}
