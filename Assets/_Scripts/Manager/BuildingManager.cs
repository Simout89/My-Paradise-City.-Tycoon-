using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BuildingManager: MonoBehaviour
{
    public Dictionary<int, BaseBuilding> building = new Dictionary<int, BaseBuilding>();

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
        this.building.Add(this.building.Count + 1, building);
    }

    private void HandleTick()
    {
        foreach (KeyValuePair<int, BaseBuilding> kvp in this.building)
        {
            if(kvp.Value.Money > 0 && (kvp.Value.flying == false))
            {
                currencyManager.AddMoney(kvp.Value.Money);
            }
        }
    }

    public int GetBuildingCount<T>(T instance) where T : MonoBehaviour
    {
        T[] allObjects = FindObjectsOfType<T>();

        return allObjects.Length;
    }
}
