using System.Net.Mime;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake() 
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != null)
        {
            Debug.Log("More than one BuildManager in scene !");
            return;
        }   
    }

    private TurretBlueprint turretToBuild;
    private TurretContainer selectedTurretContainer;
    public GameObject standardTurret;
    public GameObject buildEffect;
    public GameObject sellEffect;
    public GameObject upgradeEffect;
    public TurretUI turretUI;

    AudioManager am;

    // Start is called before the first frame update
    void Start()
    {
        // turretToBuild = standardTurret;
        am = AudioManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // public GameObject GetTurretToBuild()
    // {
    //     return turretToBuild;
    // }

    // public void SetTurretToBuild(GameObject turret)
    // {
    //     turretToBuild = turret;
    // }

    public bool CanBuild
    {
        get 
        {
            return turretToBuild != null;
        }
    }

    public bool HasMoney
    {
        get 
        {
            return turretToBuild.buildCost <= PlayerStats.money;
        }
    }

    public void SelectContainer(TurretContainer container)
    {
        am.PlayAudioShot("Click2");
        if(selectedTurretContainer == container)
        {
            DeselectContainer();
            return;
        }

        selectedTurretContainer = container;
        turretToBuild = null;

        turretUI.SetTarget(container);
    }

    public void DeselectContainer()
    {
        selectedTurretContainer = null;
        turretUI.HideUI();
        turretUI.Range.SetActive(true);
        turretUI.Range2.SetActive(true);
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectContainer();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
}
