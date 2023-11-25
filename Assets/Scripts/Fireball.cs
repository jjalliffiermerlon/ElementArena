<<<<<<< Updated upstream
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
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour, AttackElement
{
    [SerializeField] private float fireballSpeed = 15f;
    [SerializeField] private int countUseMax = 3;
    public GameObject fireball;

    public int getUseCount() //not used
    {
        return countUseMax;
    } 

    public void Use()
    {
        Debug.Log("I cast FIREBALL!!!");
        Transform dep = gameObject.transform;
        GameObject ball =Instantiate(fireball);
        ball.transform.position = dep.position;
        ball.transform.rotation = dep.rotation;
        ball.GetComponent<Rigidbody2D>().velocity = dep.TransformDirection(fireballSpeed * Vector2.up );

    }
}
>>>>>>> Stashed changes
