using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Component fields
    private Player player;


    //Input Fields
    private Vector2 movementInput = Vector2.zero;


    //UnityEvent Methods
    public void OnMovement(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }

    public void OnUtilElement()
    {
        player.UtilElement();
    }

    public void OnAttackElement()
    {
        player.AttackElement();
    }

    public void OnComboElement()
    {
        //player.CombotElement();
    }


    private void Start()
    {
        player = gameObject.GetComponent<Player>();
    }

    private void FixedUpdate()
    {
        player.Move(movementInput);
    }
}
