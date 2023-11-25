using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireElementScript : MonoBehaviour
{
    private ElementManager playerElementManager;
    [SerializeField] GameObject fireballPrefab;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerElementManager = collision.gameObject.GetComponent<ElementManager>();
            //playerElementManager.GetNewAttackElement(fireballPrefab);
            Debug.Log("Element ramassé");
            Destroy(this.gameObject);
        }
    }
}