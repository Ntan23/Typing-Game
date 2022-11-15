using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    BuildManager buildManager;
    public static bool isClicked = true;
    public Color selectedColor;
    
    // Start is called before the first frame update
    void Start()
    {
        buildManager = BuildManager.instance;
    }
    
    public void SelectStandardTurret(Image buttonImg)
    {
        if(isClicked)
        {
            buttonImg.color = selectedColor;
            Debug.Log("Standard Turret Selected");
            buildManager.SelectTurretToBuild(standardTurret);
            isClicked = false;
        }
        else if(!isClicked)
        {
            buttonImg.color = Color.white;
            UnSelectTurret();
            isClicked = true;
        }
    }

    public void UnSelectTurret()
    {
        Debug.Log("Unselect Successful !");
        buildManager.SelectTurretToBuild(null);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
