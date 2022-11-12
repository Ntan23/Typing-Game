using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    BuildManager buildManager;
    bool isClicked = true;
    
    // Start is called before the first frame update
    void Start()
    {
        buildManager = BuildManager.instance;
    }
    
    public void SelectStandardTurret()
    {
        if(isClicked)
        {
            Debug.Log("Standard Turret Selected");
            buildManager.SelectTurretToBuild(standardTurret);
            isClicked = false;
        }
        else if(!isClicked)
        {
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
