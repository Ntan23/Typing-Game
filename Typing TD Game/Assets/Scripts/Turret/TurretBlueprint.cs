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
    public int cost;
    public Sprite selectedUI;
    public Sprite unselectedUI;
    public float upgradeCost;
    public bool isSelected = false;
}
