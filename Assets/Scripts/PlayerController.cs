using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Component fields
    private Player player;


    //Input Fields
    private Vector2 movementInput = Vector2.zero;


    //UnityEvent Methods
    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
        player.Move(movementInput);
    }

    public void OnUtilElement(InputAction.CallbackContext context)
    {
        player.UtilElement();
    }

    public void OnAttackElement(InputAction.CallbackContext context)
    {
        player.AttackElement();
    }


    private void Start()
    {
        player = gameObject.GetComponent<Player>();
    }
    
}
