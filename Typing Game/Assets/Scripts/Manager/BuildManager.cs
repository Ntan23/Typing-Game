using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private GameObject turretToBuild;
    public GameObject standardTurret;
    // Start is called before the first frame update
    void Start()
    {
        turretToBuild = standardTurret;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
}
