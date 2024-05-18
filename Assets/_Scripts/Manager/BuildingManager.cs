using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BuildingManager: MonoBehaviour
{
    Dictionary<int, GameObject> building = new Dictionary<int, GameObject>();

    [Inject]
    private BuildingGrid _buildingGrid;

    private void OnEnable()
    {
        _buildingGrid.onPlaceBuilding += HandlePlaceBuilding;
    }
    private void OnDisable()
    {
        _buildingGrid.onPlaceBuilding -= HandlePlaceBuilding;
    }

    private void HandlePlaceBuilding(GameObject building)
    {
        this.building.Add(this.building.Count + 1, building);

        foreach(KeyValuePair<int, GameObject> kvp in this.building)
        {
            Debug.Log(kvp.Value);
        }
    }
}
