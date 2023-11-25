using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindDash : MonoBehaviour, UtilElement
{
    public bool CanDash = true;
    public bool IsDashing;
    [SerializeField] private float DashTime = 1f;
    [SerializeField] private float DashForce = 2f;

    [SerializeField] private float DashCooldown = 1.5f;
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
        CanDash = false;
        IsDashing = true;
        playerScript.rg.velocity = playerScript.playerOrientation * DashForce;
        yield return new WaitForSeconds(DashTime);
        IsDashing = false;
        yield return new WaitForSeconds(DashCooldown);
        CanDash = true;
    }
    public void Use()
    {
        Debug.Log("Je dash wind wind");
        if (CanDash)
        {
            StartCoroutine(Dash());
        }
    }
}