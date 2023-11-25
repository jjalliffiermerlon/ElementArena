using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class LobbyInputManager : MonoBehaviour
{
    private static List<InputDevice> playersInputDevices;

    //Ajoute petit � petit les input des joueurs � la liste
    void OnPlayerJoined(PlayerInput newPlayer)
    {
        InputDevice newPlayerDevice = newPlayer.devices[0];
        playersInputDevices.Add(newPlayerDevice);
    }

    public void Start()
    {
        playersInputDevices = new List<InputDevice>();
    }
}
