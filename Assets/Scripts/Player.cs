using UnityEngine;

public class Player : MonoBehaviour
{
    // Variable modifiable sur Unity
    [SerializeField] private float speed = 10f;
    
    private Rigidbody2D rg;
    private ElementManager elementManager;

    // Prépare le rigidbody
    void Start()
    {
        rg = gameObject.GetComponent<Rigidbody2D>();
        elementManager = gameObject.GetComponent<ElementManager>();
    }

    // Déplace le joueur
    public void Move(Vector2 movement)
    {
        rg.velocity = movement * speed * Time.fixedDeltaTime;
        if (movement != Vector2.zero)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, movement);
        }
    }
    // lance le Coup de poing
    void Punch()
    {
        
    }
    //lance l'élément offensif
    public void AttackElement()
    {
        if (elementManager.GetAttackElement() != null)
        {
            elementManager.UseAttackElement();
        }
    }
    
    // lance l'élément utilitaire
    public void UtilElement()
    {
        
    }
    
    // gère la mort du joueur
    public void Die()
    {
        Destroy(gameObject);
    }
    
    void Update()
    {
       
    }
    
}