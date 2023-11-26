using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    // Variable modifiable sur Unity
    [FormerlySerializedAs("CanDash")] public bool canDash = true;
    [FormerlySerializedAs("IsDashing")] public bool isDashing;
    [SerializeField] private float speed = 10f;
    
    [FormerlySerializedAs("rg")] public Rigidbody2D rb;
    private ElementManager elementManager;
    public Vector2 playerOrientation;
    [SerializeField] Sprite[] Sprites;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] int numberSpriteCharacter;
    [SerializeField] public float DashTime = 0.2f;
    [SerializeField] public float DashForce = 15f;

    [SerializeField] public float DashCooldown = 0.5f;

    //Numéro du ce joueur
    public int playerID;
    //Position du spawn du joueur
    public Vector2 spawnPosition;

    // Prépare le rigidbody
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
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
        if (isDashing) // si on dash, on bouge pas
        {
            return;
        }
        rb.velocity = movement * speed * Time.fixedDeltaTime;
        if (movement != Vector2.zero)
        {
            playerOrientation = rb.velocity.normalized;
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
        if (isDashing)
        {
            return;
        }
        elementManager.UseAttackElement();
    }
    
    // lance l'élément utilitaire
    public void UtilElement()
    {
        if (isDashing)
        {
            return;
        }
        elementManager.UseUtileElement();
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
        AudioManager.Instance.playDeathSound();
        Destroy(gameObject);
    }

    IEnumerator Dashending()
    {
       yield return new WaitForSeconds(DashTime);
       isDashing = false;
       yield return new WaitForSeconds(DashCooldown);
       canDash = true;

    }
    
    void Update()
    {
        if (isDashing)
        {
            StartCoroutine(Dashending());
        }
    }
    
}