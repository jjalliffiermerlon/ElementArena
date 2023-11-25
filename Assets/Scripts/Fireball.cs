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
        GameObject ball =Instantiate(fireball, dep);
        transform.LookAt(dep);
        ball.GetComponent<Rigidbody2D>().velocity = dep.TransformDirection(fireballSpeed * Vector2.up );

    }
}
