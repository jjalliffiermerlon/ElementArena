using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreLayoutGroupScript : MonoBehaviour
{
    [SerializeField] private RoundManagerScript roundManager;
    [SerializeField] private GameObject playerScorePannelPrefab;

    void Start()
    {
        for (int i = 0; i < roundManager.numberOfPlayer; i++)
        {
            GameObject scorePlayerObject = Instantiate(playerScorePannelPrefab);
            scorePlayerObject.transform.SetParent(transform);
        }

    }
}
