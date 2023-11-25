using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent (typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    //Variable fields
    [SerializeField]
    private float playerSpeed = 2.0f;

    //Component fields
    private CharacterController controller;


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
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {

        Vector2 move = new Vector2(movementInput.x, movementInput.y);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector2.zero)
        {
            gameObject.transform.forward = move;
        }

        if(utilElement) { Debug.Log("UtilElement trigger"); }
        if(attackElement) { Debug.Log("AttackElement trigger"); }
    }
}
