using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class HappyManager : ValueManager
{
    private int Happy;

    [Inject]
    private UpgradeMenu _upgradeMenu;
    [Inject]
    private BuildingManager buildingManager;

    private void Awake()
    {
        ValueChanged(Happy);
    }

    private void OnEnable()
    {
        buildingManager.OnBuildPlace += MapChanged;
        _upgradeMenu.OnUpgrade += MapChanged;
    }

    private void OnDisable()
    {
        _upgradeMenu.OnUpgrade -= MapChanged;
        buildingManager.OnBuildPlace -= MapChanged;

    }

    private void MapChanged()
    {
        Happy = 0;
        foreach (var build in buildingManager.building)
        {
            Happy += build.Happy;
        }
        ValueChanged(Happy);
    }

    public bool EnoughHappy(int Happy)
    {
        if (Happy <= this.Happy)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
