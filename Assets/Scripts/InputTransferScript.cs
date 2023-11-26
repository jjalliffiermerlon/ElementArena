using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputTransferScript : MonoBehaviour
{
    [SerializeField] LobbyInputManager inputManager;
    public static InputTransferScript instance;
    [SerializeField] public static List<InputDevice> inputDevices;
    [SerializeField] public PlayerInputManager playerInputManager;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        inputDevices = inputManager.playersInputDevices;
    }
}
