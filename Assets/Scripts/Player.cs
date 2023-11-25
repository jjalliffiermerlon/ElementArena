using UnityEngine;

public class Player : MonoBehaviour
{
    // Variable modifiable sur Unity
    [SerializeField] private float speed = 10f;
    
    public Rigidbody2D rg;
    private ElementManager elementManager;
    public Vector2 playerOrientation;
    [SerializeField] Sprite[] Sprites;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] int numberSpriteCharacter;

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
        spriteRenderer.sprite = Sprites[0 + (3 * numberSpriteCharacter)];
    }

    // Déplace le joueur
    public void Move(Vector2 movement)
    {
        rg.velocity = movement * speed * Time.fixedDeltaTime;
        if (movement != Vector2.zero)
        {
            playerOrientation = rg.velocity.normalized;
        }

        if (playerOrientation == Vector2.up)
        {
            spriteRenderer.sprite = Sprites[2 +(3 * numberSpriteCharacter)];
            spriteRenderer.flipX = false;
        }
        else if (playerOrientation == Vector2.down)
        {
            spriteRenderer.sprite = Sprites[0+(3 * numberSpriteCharacter)];
            spriteRenderer.flipX = false;
        }
        else if (playerOrientation == Vector2.left)
        {
            spriteRenderer.sprite = Sprites[1 + (3 * numberSpriteCharacter)];
            spriteRenderer.flipX = true;
        }
        else if (playerOrientation == Vector2.right)
        {
            spriteRenderer.sprite = Sprites[1 + (3 * numberSpriteCharacter)];
            spriteRenderer.flipX = false;
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
        if (RoundManagerScript.LastDeadPlayer == -1)
        {
            RoundManagerScript.LastDeadPlayer = playerID;
        }
        else
        {
            RoundManagerScript.OtherDeadPlayer = playerID;
        }
        Destroy(gameObject);
    }
    
    void Update()
    {
       
    }
    
}