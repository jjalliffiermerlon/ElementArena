using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Variable fields
    [SerializeField]
    private float playerSpeed = 2.0f;

    //Component fields
    private Player player;


    //Input Fields
    private Vector2 movementInput = Vector2.zero;
    private bool utilElement = false;
    private bool attackElement = false;


    //UnityEvent Methods
    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnUtilElement(InputAction.CallbackContext context)
    {
        //utilElement = context.ReadValue<bool>();
        utilElement = context.action.triggered;
    }

    public void OnAttackElement(InputAction.CallbackContext context)
    {
        //attackElement = context.ReadValue<bool>();
        attackElement = context.action.triggered;
    }


    
    private void Start()
    {
        player = gameObject.GetComponent<Player>();
    }
    
}
