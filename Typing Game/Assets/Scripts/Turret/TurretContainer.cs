using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretContainer : MonoBehaviour
{
    public Color hoverColor;
    private Color startColor;
    private Renderer objectRenderer;
    private GameObject turret;
    public Vector3 turretOffset;

    // Start is called before the first frame update
    void Start()
    {
        objectRenderer=GetComponent<Renderer>();
        startColor = objectRenderer.material.color;
    }

    private void OnMouseEnter() 
    {
        objectRenderer.material.color = hoverColor;
    }

    private void OnMouseExit() {
        objectRenderer.material.color = startColor;
    }

    private void OnMouseDown()
    {
        if(turret != null)
        {
            Debug.Log("You Can't Build Here!");
            return;
        }

        //Build A Turret
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();

        turret = (GameObject) Instantiate(turretToBuild,transform.position + turretOffset,transform.rotation);
    }
}
