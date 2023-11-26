using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour, AttackElement
{
    [SerializeField] public bool isCasting = false;
    [SerializeField] private bool canCast = true;
    [SerializeField] private float castcouldown = 2f;
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

    IEnumerator cast()
    {
        canCast = false;
        yield return new WaitForSeconds(castcouldown);
        canCast = true;
    }
    public void Use()
    {
        Debug.Log("I cast FIREBALL!!!");
        if (canCast){
            StartCoroutine(cast());
            isCasting = true;
            Transform dep = gameObject.transform;
            AudioManager.Instance.playFireballLaunch();
            GameObject ball =Instantiate(fireball);
            ball.transform.position = dep.position;
            ball.transform.rotation = dep.rotation;
            ball.transform.Translate(playerScript.playerOrientation * 0.25f);
            ball.GetComponent<Rigidbody2D>().velocity = dep.TransformDirection(fireballSpeed * playerScript.playerOrientation );
            isCasting = false;
        }
        
        
    }
}
