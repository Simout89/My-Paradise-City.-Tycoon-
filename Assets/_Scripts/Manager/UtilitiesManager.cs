using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class UtilitiesManager : MonoBehaviour
{
    [Inject]
    private SaveLoadSystem saveLoadSystem;
    [SerializeField] private TMP_Text _waterText;
    [SerializeField] private TMP_Text _electText;
    public int _water { get; private set; }
    public int _electricity { get; private set; }
    public int _consumptionWater { get; private set; }
    public int _consumptionElectricity { get; private set; }

    [Inject]
    private UpgradeMenu _upgradeMenu;
    [Inject]
    private BuildingManager buildingManager;

    private void OnEnable()
    {
        buildingManager.OnBuildPlace += MapChanged;
        _upgradeMenu.OnUpgrade += MapChanged;
        saveLoadSystem.DataLoaded += HandleDataLoaded;
    }

    private void OnDisable()
    {
        _upgradeMenu.OnUpgrade -= MapChanged;
        buildingManager.OnBuildPlace -= MapChanged;
        saveLoadSystem.DataLoaded -= HandleDataLoaded;
    }

    private void HandleDataLoaded()
    {
        MapChanged();
        ChangeText();
    }

    public bool CheckUtilitiesWalidate(int waterCost, int elecCost)
    {
        if(_water >= (waterCost + _consumptionWater) &&  (_electricity >= (elecCost + _consumptionElectricity)))
        {
            return true;
        }else
        {
            return false;
        }
    }

    private void MapChanged()
    {
        _water = 0;
        _electricity = 0;
        _consumptionWater = 0;
        _consumptionElectricity = 0;
        foreach (var build in buildingManager.building)
        {
            if (build.TryGetComponent(out WaterBuild waterBuild))
            {
                _water += waterBuild._water;
            }else
            if (build.TryGetComponent(out ElectricBuild electricBuild))
            {
                _electricity += electricBuild._electric;
            }else
            {
                BaseBuilding baseBuilding = build.GetComponent<BaseBuilding>();
                _consumptionWater += baseBuilding.WaterCost;
                _consumptionElectricity += baseBuilding.ElectricCost;
            }   
            
        }
        print($"Water: {_water} Elect: {_electricity}");
        ChangeText();
    }


    private void ChangeText()
    {
        _waterText.text = $"{_consumptionWater}/{_water}";
        _electText.text = $"{_consumptionElectricity}/{_electricity}";
    }
}
