using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindDash : MonoBehaviour , AttackElement
{
    private bool CanDash = true;
    private bool IsDashing;
    [SerializeField] private float DashTime = 0.2f;
    [SerializeField] private float DashForce = 2f;

    [SerializeField] private float DashCooldown = 0.5f;
    [SerializeField] private int countUseMax = 3;

    public int getUseCount() //not used
    {
        return countUseMax;
    }

    public void Use()
    {
        
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
