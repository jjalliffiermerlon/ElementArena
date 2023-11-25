using UnityEngine;

public class Player : MonoBehaviour
{
    // Variable modifiable sur Unity
    [SerializeField] private float speed = 10f;
    
    public Rigidbody2D rg;
    private ElementManager elementManager;
    public Quaternion playerOrientation;

    //Numéro du ce joueur
    public int playerID;
    //Position du spawn du joueur
    public Vector2 spawnPosition;

    // Prépare le rigidbody
    void Awake()
    {
        rg = gameObject.GetComponent<Rigidbody2D>();
        elementManager = gameObject.GetComponent<ElementManager>();
    }

    private void Start()
    {
        transform.position = spawnPosition;
    }

    // Déplace le joueur
    public void Move(Vector2 movement)
    {
        rg.velocity = movement * speed * Time.fixedDeltaTime;
        if (movement != Vector2.zero)
        {
            playerOrientation = Quaternion.LookRotation(Vector3.forward, movement);
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