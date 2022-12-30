using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurretUI : MonoBehaviour
{
    public GameObject UI;
    public TextMeshProUGUI upgradeCost;
    public TextMeshProUGUI sellAmount;
    public Button upgradeButton;
    public GameObject moneyIcon;

    public GameObject Range;
    public GameObject Range2;
    private TurretContainer target;
    [SerializeField] Shop shop;

    private void Start() {
    }

    public void SetTarget(TurretContainer _target)
    {
        target = _target;
        if(target.turret.CompareTag("Fire")){
        transform.position = target.GetBuildPosition();

     
        Range2.SetActive(false);
        }

        if(target.turret.CompareTag("AoE")){
        transform.position = target.GetBuildPosition();

        Range.SetActive(false);

        }

      


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
            moneyIcon.SetActive(true);
        }
        else if(target.isUpgraded)
        {
            upgradeCost.text = "MAX";
            upgradeButton.interactable = false;
            moneyIcon.SetActive(false);
        }

        sellAmount.text = target.turretBlueprint.GetSellAmount().ToString();

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

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectContainer();
    }
}
