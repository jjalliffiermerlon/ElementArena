using System.Collections.Generic;
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

    //Methode lancée quand un joueur rejoint la partie
    void OnPlayerJoined(PlayerInput newPlayer)
    {
        Debug.Log("wesh");
        //SetPlayer ID of the new player
        newPlayer.gameObject.GetComponent<Player>().playerID = newPlayer.playerIndex + 1;

        RoundManagerScript.CollectingPlayers(newPlayer.gameObject, newPlayer.playerIndex);

        //Set start position of the new player
        //newPlayer.gameObject.transform.position = spawnLocations[newPlayer.playerIndex].position;

        //Debug.Log(newPlayer.gameObject.transform.position);
        players.Add(newPlayer.gameObject);
        newPlayer.gameObject.SetActive(false);
    }
    
    public void startGame()
    {
        var list = FindObjectsByType<PlayerInput>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        foreach(var player in list)
        {
            player.gameObject.SetActive(true);
            player.gameObject.transform.position = spawnLocations[player.playerIndex].position;
        }
    }
}
