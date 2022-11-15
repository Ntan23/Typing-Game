using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretUI : MonoBehaviour
{
    public GameObject UI;
    private TurretContainer target;

    public void SetTarget(TurretContainer _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();
        UI.SetActive(true);
    }

    public void HideUI()
    {
        UI.SetActive(false);
    }
}
