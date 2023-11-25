using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour, AttackElement
{
    [SerializeField] private float fireballSpeed = 15f;
    [SerializeField] private int countUseMax = 3;
    public GameObject fireball;
    private Player playerScript;

    public void Start()
    {
        playerScript=GetComponentInParent<Player>();
    }

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
        ball.transform.Translate(playerScript.playerOrientation * 0.25f);
        ball.GetComponent<Rigidbody2D>().velocity = dep.TransformDirection(fireballSpeed * playerScript.playerOrientation );

    }
}
