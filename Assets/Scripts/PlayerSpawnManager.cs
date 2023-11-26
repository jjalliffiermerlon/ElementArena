using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawnManager : MonoBehaviour
{
    public Transform[] spawnLocations;
    [SerializeField] RoundManagerScript RoundManagerScript;
    private PlayerInputManager playerInputManager;

    //Initialisation des champs
    private void Awake()
    {
        playerInputManager = GetComponent<PlayerInputManager>();
    }

    //Methode appel� par le RoundManager pour spawn les joueurs
    public void AddPlayer(InputDevice inputDevice)
    {
        playerInputManager.JoinPlayer(-1, -1, null, inputDevice);
    }

    //Methode lanc�e quand un joueur rejoint la partie
    void OnPlayerJoined(PlayerInput newPlayer)
    {
        //SetPlayer ID of the new player
        newPlayer.gameObject.GetComponent<Player>().playerID = newPlayer.playerIndex + 1;

        //Set start position of the new player
        newPlayer.gameObject.GetComponent<Player>().spawnPosition = spawnLocations[newPlayer.playerIndex].position;

        //RoundManagerScript.collectingPlayer(newPlayer.gameObject, newPlayer.playerIndex);
    }
}
