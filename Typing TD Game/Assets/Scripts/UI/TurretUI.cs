using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class TurretUI : MonoBehaviour, IPointerEnterHandler
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

    AudioManager am;

    private void Start(){
        am = AudioManager.instance;
    }

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

        if(target.turret.CompareTag("Fire") || target.turret.CompareTag("AoE"))
        {
            Range.SetActive(true);
            Range2.SetActive(false);
        }
        else if(target.turret.CompareTag("Fire2") || target.turret.CompareTag("AoE2"))
        {
            Range.SetActive(false);
            Range2.SetActive(true);
        }

        if(!target.isUpgraded)
        {
            upgradeCost.text = target.turretBlueprint.upgradeCost.ToString();
            upgradeButton.interactable = true;
            moneyIcon.SetActive(true);
            sellAmount.text = target.turretBlueprint.GetSellAmount().ToString();
        }
        else if(target.isUpgraded)
        {
            upgradeCost.text = "MAX";
            upgradeButton.interactable = false;
            moneyIcon.SetActive(false);
            sellAmount.text = target.turretBlueprint.GetSellAmount_Upgraded().ToString();
        }

   

        UI.SetActive(true);
    }

    public void HideUI()
    {
        UI.SetActive(false);
        Range.SetActive(false);
        Range2.SetActive(false);
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

    public void OnPointerEnter(PointerEventData EventData)
    {
        if(upgradeButton.interactable)
        am.PlayAudioShot("Hover3");
    }

}
