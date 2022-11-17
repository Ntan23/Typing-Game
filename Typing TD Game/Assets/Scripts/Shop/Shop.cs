using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public TurretBlueprint[] turrets;
    BuildManager buildManager;
    public static bool isClicked = true;
    public static bool canUpdateColor;
    public Color selectedColor;
    Image tempImage;
    
    // Start is called before the first frame update
    void Start()
    {
        buildManager = BuildManager.instance;
    }
    
    public void SelectStandardTurret(Image buttonImg)
    {
        if(tempImage != null)
        {
            tempImage.color = Color.white;
            UnSelectTurret();
        }

        tempImage = buttonImg;
        
        if(isClicked)
        {
            buttonImg.color = selectedColor;
            Debug.Log("Standard Turret Selected");
            buildManager.SelectTurretToBuild(turrets[0]);
            isClicked = false;
            canUpdateColor = true;
        }
        else if(!isClicked)
        {
            buttonImg.color = Color.white;
            UnSelectTurret();
            isClicked = true;
            canUpdateColor = false;
        }
    }

    public void SelectAoETurret(Image buttonImg)
    {   
        if(tempImage != null)
        {
            tempImage.color = Color.white;
            UnSelectTurret();
        }

        tempImage = buttonImg;

        if(isClicked)
        {
            buttonImg.color = selectedColor;
            Debug.Log("AoE Turret Selected");
            buildManager.SelectTurretToBuild(turrets[1]);
            isClicked = false;
            canUpdateColor = true;
        }
        else if(!isClicked)
        {
            buttonImg.color = Color.white;
            UnSelectTurret();
            isClicked = true;
            canUpdateColor = false;
        }
    }

    public void UnSelectTurret()
    {
        Debug.Log("Unselect Successful !");
        buildManager.SelectTurretToBuild(null);
    }

    void ChangeToOriginalColor()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
