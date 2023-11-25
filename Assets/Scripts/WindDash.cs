using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindDash : MonoBehaviour, UtilElement
{
    [SerializeField] private float DashTime = 0.2f;
    [SerializeField] private float DashForce = 15f;

    [SerializeField] private float DashCooldown = 0.5f;
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

    private IEnumerator Dash()
    {
        playerScript.CanDash = false;
        playerScript.IsDashing = true;
        playerScript.rg.velocity = playerScript.playerOrientation * DashForce;
        yield return new WaitForSeconds(DashTime);
        playerScript.IsDashing = false;
        yield return new WaitForSeconds(DashCooldown);
        playerScript.CanDash = true;
    }
    public void Use()
    {
        Debug.Log("Je dash wind wind");
        if (playerScript.CanDash)
        {
            StartCoroutine(Dash());
        }
    }
}