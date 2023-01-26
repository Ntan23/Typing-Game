using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TurretContainer : MonoBehaviour
{
    // public Color hoverColor;
    // private Color startColor;
    public Material hoverMaterial;
    public Material cannotBuildMaterial;
    private Material startMaterial;
    private Renderer objectRenderer;
    public Vector3 turretOffset;
    [HideInInspector] public GameObject turret;
    [HideInInspector] public TurretBlueprint turretBlueprint;
    [HideInInspector] public bool isUpgraded = false;
    BuildManager buildManager;
    GameManager gm;

    AudioManager am;

    // Start is called before the first frame update
    void Start()
    {
        buildManager = BuildManager.instance;
        gm = GameManager.instance;
        objectRenderer = GetComponent<Renderer>();
        // startColor = objectRenderer.material.color;
        am = AudioManager.instance;
        startMaterial = objectRenderer.material;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + turretOffset;
    }

    private void OnMouseEnter() 
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if(!buildManager.CanBuild)
        {
            return;
        }
        
        if(turret != null)
        {
           objectRenderer.material = cannotBuildMaterial;
        }

        objectRenderer.material = buildManager.HasMoney ? hoverMaterial  : cannotBuildMaterial;

        am.PlayAudioShot("Node_Hover");    

        // if(buildManager.HasMoney)
        // {
        //     objectRenderer.material.color = hoverColor;
        // }
        // else if(!buildManager.HasMoney)
        // {
        //     objectRenderer.material.color = Color.red;
        // }
    }

    void OnMouseOver()
    {
        if(turret != null && !gm.gameEnded)
        {
            if(turretBlueprint.isSelected)
            {
                objectRenderer.material = cannotBuildMaterial;
            }
            else if(!turretBlueprint.isSelected)
            {
                return;
            } 
        }
        else if(turret == null && !gm.gameEnded)
        {
            return;
        }
    }

    private void OnMouseExit()
    {
        objectRenderer.material = startMaterial;
    }

    private void OnMouseDown()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if(turret != null)
        {
            buildManager.SelectContainer(this);
            // Debug.Log("You Can't Build Here!");
            return;
        }

        if(!buildManager.CanBuild)
        {
            return;
        }

        //Build A Turret
        BuildTurret(buildManager.GetTurretToBuild());


        // GameObject turretToBuild = buildManager.GetTurretToBuild();

        // turret = (GameObject) Instantiate(turretToBuild,transform.position + turretOffset,transform.rotation);
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        if(PlayerStats.money < blueprint.buildCost)
        {
            am.PlayAudioShot("TurretUnable");
            Debug.Log("Not Enough Money To Build That!");
            return;
        }

        PlayerStats.money -= blueprint.buildCost;
        MoneyUI.needUpdate = true;

        GameObject _turret = (GameObject) Instantiate(blueprint.turret,GetBuildPosition(),blueprint.turret.transform.rotation);
        am.PlayAudioShot("PlaceTurret");
        turret = _turret;
        // Debug.Log("Turret Build! Money left : "+PlayerStats.money);

        turretBlueprint = blueprint;

        GameObject effect = (GameObject) Instantiate(buildManager.buildEffect,GetBuildPosition(),Quaternion.identity);
        Destroy(effect,1.0f);
    }

    public void UpgradeTurret()
    {
        if(PlayerStats.money < turretBlueprint.upgradeCost)
        {
            am.PlayAudioShot("TurretUnable");
            Debug.Log("Not Enough Money To Upgrade That!");
            return;
        }

        PlayerStats.money -= turretBlueprint.upgradeCost;
        MoneyUI.needUpdate = true;
        
        Destroy(turret);

        am.PlayAudioShot("TurretUpgrade");

        GameObject _turret = (GameObject) Instantiate(turretBlueprint.upgradedTurret,GetBuildPosition(),Quaternion.identity);
        turret = _turret;
        // Debug.Log("Turret Build! Money left : "+PlayerStats.money);
    
        GameObject effect = (GameObject) Instantiate(buildManager.upgradeEffect,GetBuildPosition(),Quaternion.identity);
        Destroy(effect,1.5f);
        isUpgraded = true;
    }

    public void SellTurret()
    {
        if(!isUpgraded)
        {
        PlayerStats.money += turretBlueprint.GetSellAmount();
        }

        else if(isUpgraded)
        {
        PlayerStats.money += turretBlueprint.GetSellAmount_Upgraded();
        }
       
        MoneyUI.needUpdate = true; 

        //Spawn A Sell Effect
        GameObject effect = (GameObject) Instantiate(buildManager.sellEffect,GetBuildPosition(),Quaternion.identity);
        am.PlayAudioShot("SellTurret");
        Destroy(effect,1.5f);

        Destroy(turret);
        turretBlueprint = null;
        isUpgraded = false;
    }
}
