using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIreballbehavior : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().Die();
        }
        //else if (other.CompareTag("Crate"))
        //{
        //other.GetComponent<Crate>().BreakCrate  
        //}
        AudioManager.Instance.playFireballHit();
        Destroy(gameObject);
    }
}
