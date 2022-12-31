using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TurretBlueprint
{
    public string name;
    public GameObject turret;
    public GameObject upgradedTurret;
    public Sprite selectedUI;
    public Sprite unselectedUI;
    public float buildCost;
    public float upgradeCost;
    public bool isSelected = false;

    public float GetSellAmount()
    {
        return buildCost/2;  
    }

    public float GetSellAmount_Upgraded()
    {
        return buildCost+upgradeCost/2;
    }


}
