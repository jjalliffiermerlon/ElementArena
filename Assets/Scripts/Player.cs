
using UnityEngine;

public class Player : MonoBehaviour
{
    // Variable modifiable sur Unity
    [SerializeField] private float speed = 10f;
    [SerializeField] private float knockbackPunch = 10f;
    private Rigidbody2D rg;

    // Prépare le rigidbody
    void Start()
    {
        rg = gameObject.GetComponent<Rigidbody2D>();
    }
    
    // Déplace le joueur
    public void Move(Vector2 movement)
    {
        rg.velocity = movement * speed;
    }

    // lance le Coup de poing
    void Punch()
    {
        
    }
    //lance l'élément offensif
    public void AttackElement()
    {
        
    }
    
    // lance l'élément utilitaire
    public void UtilElement()
    {
        
    }
    
    // gère la mort du joueur
    public void Die()
    {
        
    }
    
    void Update()
    {
       
    }
    
}