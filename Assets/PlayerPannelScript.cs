using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPannelScript : MonoBehaviour
{
    [SerializeField] RoundManagerScript roundManagerScript;
    [SerializeField] Image fireballeSpriteRenderer;
    [SerializeField] Sprite fireballsprite;

    private void Update()
    {
        if(roundManagerScript.SpawnedPlayers[1].GetComponent<ElementManager>().attackElementGO!= null)
        {
            fireballeSpriteRenderer.sprite = fireballsprite;
        }
        else if((roundManagerScript.SpawnedPlayers[1].GetComponent<ElementManager>().attackElementGO == null))
        {
            fireballeSpriteRenderer.sprite = null;
        }
    }
}
