using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindElementScript : MonoBehaviour
{
    private ElementManager playerElementManager;
    [SerializeField] GameObject windDashPrefab;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerElementManager = collision.gameObject.GetComponent<ElementManager>();
            playerElementManager.GetNewUtilElement(windDashPrefab);
            Debug.Log("Element ramass�");
            Destroy(this.gameObject);
        }
    }
}
