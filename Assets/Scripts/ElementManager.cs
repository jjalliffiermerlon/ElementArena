using UnityEngine;

public class ElementManager : MonoBehaviour
{
    [SerializeField]
    private GameObject utilElementGO;
    private UtilElement utilElement;
    private int utilElementUseLeft = 0;

    [SerializeField]
    private GameObject attackElementGO;
    private AttackElement attackElement;
    private int attackElementUseLeft = 0;

    //Use the element and reduce 1 use (Remove the element if useleft = 0)
    public void UseUtileElement()
    {
        utilElement.Use();
        utilElementUseLeft -= 1;
        if (utilElementUseLeft <= 0) { RemoveUtilElement(); }
    }

    public void UseAttackElement()
    {
        attackElement.Use();
        attackElementUseLeft -= 1;
        if(attackElementUseLeft <= 0) { RemoveAttackElement(); }
    }

    //Accesseurs
    public UtilElement GetUtilElement()
    {
        return utilElement;
    }

    public AttackElement GetAttackElement()
    {
        return attackElement;
    }


    //Methods calls when a new element is get
    public void GetNewUtilElement(GameObject utilElementPrefab)
    {
        if(utilElement == null) { RemoveUtilElement(); }
        CreateUtilElement(utilElementPrefab);
    }

    public void GetNewAttackElement(GameObject attackElementPrefab)
    {
        if (attackElement == null) { RemoveAttackElement(); }
        CreateAttackElement(attackElementPrefab);
    }

    /*-----------------------------------------Private Methods, nothing to see----------------------------------------*/
    //Instantiate a new element and update fields
    private void CreateUtilElement(GameObject utilElementPrefab)
    {
        utilElementGO = Instantiate(utilElementPrefab, transform);
        utilElementGO.transform.parent = gameObject.transform;
        utilElement = utilElementGO.GetComponent<UtilElement>();
        utilElementUseLeft = utilElement.getUseCount();
    }
    private void CreateAttackElement(GameObject attackElementPrefab)
    {
        attackElementGO = Instantiate(attackElementPrefab,transform);
        attackElementGO.transform.parent = gameObject.transform;
        attackElement = attackElementGO.GetComponent<AttackElement>();
        attackElementUseLeft = attackElement.getUseCount();
    }

    
    //Detroy a Element Game Object and reset link fields
    private void RemoveUtilElement()
    {
        utilElement = null;
        utilElementUseLeft = 0;
        Destroy(utilElementGO);
    }

    private void RemoveAttackElement() { 
        attackElement = null;
        utilElementUseLeft = 0;
        Destroy(attackElementGO);
    }
    
}
