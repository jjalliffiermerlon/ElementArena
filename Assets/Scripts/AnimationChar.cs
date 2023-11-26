using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationChar : MonoBehaviour
{
    private Animator pAnimator;
    private Fireball fire;
    
    // Start is called before the first frame update
    void Start()
    {
        pAnimator = GetComponent<Animator>;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pAnimator != null)
        {
            if (fire.isCasting)
            {
                pAnimator.SetTrigger("boule de feu");
            }
        }
    }
}
