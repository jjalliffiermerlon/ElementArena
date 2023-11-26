using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class LobbyInputManager : MonoBehaviour
{
    public List<InputDevice> playersInputDevices;
    public static LobbyInputManager instance;
    [SerializeField] private GameObject[] playerSelection;

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

    //Ajoute petit à petit les input des joueurs à la liste
    void OnPlayerJoined(PlayerInput newPlayer)
    {
        InputDevice newPlayerDevice = newPlayer.devices[0];
        playersInputDevices.Add(newPlayerDevice);

        /*if (playersInputDevices.Count == 1)
        {
            playerSelection[1].SetActive(true);
        }
        else if (playersInputDevices.Count == 2)
        {
            playerSelection[1].SetActive(true);
            playerSelection[2].SetActive(true);
        }
        else if (playersInputDevices.Count == 3)
        {
            playerSelection[1].SetActive(true);
            playerSelection[2].SetActive(true);
            playerSelection[3].SetActive(true);
        }
        else if (playersInputDevices.Count == 4)
        {
            playerSelection[1].SetActive(true);
            playerSelection[2].SetActive(true);
            playerSelection[3].SetActive(true);
            playerSelection[3].SetActive(true);
        }*/
    }

    public void Start()
    {
        playersInputDevices = new List<InputDevice>();
    }
}
