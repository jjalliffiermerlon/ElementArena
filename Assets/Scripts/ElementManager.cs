using UnityEngine;

public class ElementManager : MonoBehaviour
{
    private UtilElement utilElement;
    private int utilElementUseLeft = 0;

    private AttackElement attackElement;
    private int attackElementUseLeft = 0;


    public void UseUtileElement()
    {
        utilElement.Use();
    }

    public void UseAttackElement()
    {
        attackElement.Use();
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
}
