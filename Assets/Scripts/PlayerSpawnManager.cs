using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawnManager : MonoBehaviour
{
    public Transform[] spawnLocations;
    [SerializeField] RoundManagerScript RoundManagerScript;
    public PlayerInputManager playerInputManager;

    private List<GameObject> players = new List<GameObject>();

    //Initialisation des champs
    private void Awake()
    {
        playerInputManager = FindObjectOfType<PlayerInputManager>();
    }

    //Methode appelé par le RoundManager pour spawn les joueurs
    public void AddPlayer(InputDevice inputDevice, int index)
    {
        playerInputManager.JoinPlayer(index, -1, null, inputDevice);
    }
    
    public void startGame()
    {
        Debug.Log("c'est start game");
        var list = FindObjectsByType<PlayerInput>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        foreach(var player in list)
        {
            player.gameObject.transform.position = spawnLocations[player.playerIndex].position;

            player.gameObject.GetComponent<Player>().playerID = player.playerIndex;
            Debug.Log(player.playerIndex);
            RoundManagerScript.SpawnedPlayers[player.playerIndex] = player.gameObject;
        }
    }
}
