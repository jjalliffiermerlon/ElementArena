using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindDash : MonoBehaviour, UtilElement
{
    
    [SerializeField] private int countUseMax = 3;

    private Player playerScript;

    public void Start()
    {
        playerScript = GetComponentInParent<Player>(); //Search our public variable
    }

    public int getUseCount() //not used
    {
        return countUseMax;
    }

    public IEnumerator Dash()
    {
        AudioManager.Instance.playWindDash();
        playerScript.canDash = false;
        playerScript.isDashing = true;
        playerScript.rb.velocity = playerScript.playerOrientation * playerScript.DashForce;
        yield return new WaitForSeconds(playerScript.DashTime);
        playerScript.isDashing = false;
        Debug.Log("j'ai fini de dash dash");
        yield return new WaitForSeconds(playerScript.DashCooldown);
        playerScript.canDash = true;
        Debug.Log("je peux dash");
    }
    public void Use()
    {
        Debug.Log("Je dash wind wind");
        if (playerScript.canDash)
        {
            StartCoroutine(Dash());
        }
    }
}