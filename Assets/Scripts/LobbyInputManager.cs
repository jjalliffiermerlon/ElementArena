using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class LobbyInputManager : MonoBehaviour
{
    public List<InputDevice> playersInputDevices;
    public static LobbyInputManager instance;

    /*public void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }*/

    //Ajoute petit � petit les input des joueurs � la liste
    void OnPlayerJoined(PlayerInput newPlayer)
    {
        InputDevice newPlayerDevice = newPlayer.devices[0];
        playersInputDevices.Add(newPlayerDevice);
        AudioManager.Instance.playMenuSound("Join");
    }

    public void Start()
    {
        playersInputDevices = new List<InputDevice>();
    }
}
