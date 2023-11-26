using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustForMusic : MonoBehaviour
{
    private void Start()
    {
        AudioManager.Instance.playMusic("Menu");
    }
}
