using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BuildingManager: MonoBehaviour
{
    public List<BaseBuilding> building = new List<BaseBuilding>();

    public event Action OnBuildPlace;

    [Inject]
    private BuildingGrid _buildingGrid;
    [Inject]
    private TimeManager timeManager;
    [Inject]
    private CurrencyManager currencyManager;

    private void OnEnable()
    {
        timeManager.OnTick += HandleTick;
        _buildingGrid.onPlaceBuilding += HandlePlaceBuilding;
    }

    private void OnDisable()
    {
        timeManager.OnTick -= HandleTick;
        _buildingGrid.onPlaceBuilding -= HandlePlaceBuilding;
    }

    private void HandlePlaceBuilding(BaseBuilding building)
    {
        this.building.Add(building);
        OnBuildPlace?.Invoke();
    }

    public void LoadBuild(BaseBuilding building)
    {
        this.building.Add(building);
        OnBuildPlace?.Invoke();
    }

    private void HandleTick()
    {
        foreach(var building in this.building)
        {
            currencyManager.AddMoney(building.Money);
        }
    }

    public int GetBuildingCount(BuildingType index)
    {
        int count = 0;
        foreach (var building in this.building)
        {
            if (building.buildingType == index)
            {
                count++;
            }
        }
        return count;
    }
}
