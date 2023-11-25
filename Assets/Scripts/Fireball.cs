using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour, AttackElement
{
    [SerializeField] private float fireballSpeed = 15f;
    public Rigidbody2D fireball;
    public int getUseCount() //not used
    {
        return 0;
    } 

    public void Use()
    {
        Rigidbody2D ball;
        Transform dep = gameObject.transform;
        ball =Instantiate(fireball, dep);
        transform.LookAt(dep);
        ball.velocity = dep.TransformDirection(fireballSpeed * Vector2.up );

    }

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
