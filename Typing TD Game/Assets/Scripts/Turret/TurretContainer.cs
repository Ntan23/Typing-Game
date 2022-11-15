using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TurretContainer : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    private Color startColor;
    private Renderer objectRenderer;
    public Vector3 turretOffset;
    [Header("Optional")]
    public GameObject turret;
    BuildManager buildManager;

    // Start is called before the first frame update
    void Start()
    {
        buildManager = BuildManager.instance;
        objectRenderer = GetComponent<Renderer>();
        startColor = objectRenderer.material.color;
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
            hoverColor = Color.red;
        }

        objectRenderer.material.color = buildManager.HasMoney ? hoverColor : Color.red;
        
        // if(buildManager.HasMoney)
        // {
        //     objectRenderer.material.color = hoverColor;
        // }
        // else if(!buildManager.HasMoney)
        // {
        //     objectRenderer.material.color = Color.red;
        // }
    }

    private void OnMouseExit()
    {
        objectRenderer.material.color = startColor;
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
        buildManager.BuildTurret(this);
        // GameObject turretToBuild = buildManager.GetTurretToBuild();

        // turret = (GameObject) Instantiate(turretToBuild,transform.position + turretOffset,transform.rotation);
    }
}
