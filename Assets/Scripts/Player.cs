
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private Rigidbody2D rg;

    void start()
    {
        rg = gameObject.GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 movement)
    {
        
    }

    public void AttackElement()
    {
        
    }

    public void UtilElement()
    {
        
    }
    void Update()
    {
       
    }

    void FixedUpdate()
    {
      
    }
}