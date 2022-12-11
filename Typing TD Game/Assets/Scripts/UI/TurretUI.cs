using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurretUI : MonoBehaviour
{
    public GameObject UI;
    public TextMeshProUGUI upgradeCost;
    public Button upgradeButton;
    public GameObject upgradeButtonGO;
    private TurretContainer target;
    [SerializeField] Shop shop;

    public void SetTarget(TurretContainer _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();

        if(target.turretBlueprint.isSelected)
        {
            target.turretBlueprint.isSelected = false;
            shop.tempImage.color = Color.white;
            shop.tempImage.sprite = target.turretBlueprint.unselectedUI;
            shop.UnSelectTurret();
        }

        if(!target.isUpgraded)
        {
            upgradeCost.text = target.turretBlueprint.upgradeCost.ToString();
            upgradeButton.interactable = true;
            upgradeButtonGO.SetActive(true);
        }
        else if(target.isUpgraded)
        {
            upgradeCost.text = "MAX";
            upgradeButton.interactable = false;
            upgradeButtonGO.SetActive(false);
        }

        UI.SetActive(true);
    }

    public void HideUI()
    {
        UI.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectContainer();
    }
}
