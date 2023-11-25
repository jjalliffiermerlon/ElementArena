using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanvasScript : MonoBehaviour
{
    [SerializeField] RoundManagerScript roundManagerScript;
    [SerializeField] GameObject[] UIPlayerPannels;

    public void Start()
    {
        int numberOfPlayer = roundManagerScript.numberOfPlayer;
        for (int i = 0; i < numberOfPlayer; i++)
        {
            UIPlayerPannels[i].SetActive(true);
        }
    }
}
